using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WSRQuoterAPI.Models;
using WSRQuoterAPI.Models.USDADtos;
using WSRQuoterAPI.ViewModels;

namespace WSRQuoterAPI.Services
{
    public class USDASyncService : IUSDASyncService
    {
        private InsuranceDBContext _context;
        IRepositoryService _repositoryService;
        private readonly ILogger<USDASyncService> _logger;

        public USDASyncService(InsuranceDBContext context, IRepositoryService repositoryService, ILogger<USDASyncService> logger)
        {
            _context = context;
            _repositoryService = repositoryService;
            _logger = logger;
        }

        public async Task<StateListDto> GetStates()
        {
            var states = new StateListDto();

            string baseUrl = Business.Constants.GetStates;
            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage res = client.GetAsync(baseUrl).Result;
                HttpContent content = res.Content;
                var data = await content.ReadAsStringAsync();

                if (content != null)
                {
                    states = JsonConvert.DeserializeObject<StateListDto>(data);
                    _repositoryService.SaveStatesData(states);
                }

                _logger.LogInformation("States Synced");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in States Sync");
            }

            return states;
        }

        public async Task<CountyListDto> GetCounties()
        {
            var counties = new CountyListDto();

            string baseUrl = Business.Constants.GetCountiesByState;
            HttpClient client = new HttpClient();

            try
            {
                var states = new List<State>();
                states = _context.Set<State>().ToList();

                foreach (var state in states)
                {
                    string query;
                    var cont = new FormUrlEncodedContent(
                        new Dictionary<string, string>()
                        {
                            { "stateCode", state.Code},
                        });

                    query = cont.ReadAsStringAsync().Result;


                    HttpResponseMessage res = client.GetAsync(baseUrl + "?" + query).Result;
                    HttpContent content = res.Content;
                    var data = await content.ReadAsStringAsync();

                    if (content != null)
                    {
                        counties = JsonConvert.DeserializeObject<CountyListDto>(data);
                        _repositoryService.SaveCountiesData(counties, state.Code);
                    }
                }

                _logger.LogInformation("Counties Synced");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in Counties Sync");
            }

            return counties;
        }

        public async Task<SubCountyListDto> GetSubCounties()
        {
            var subCounties = new SubCountyListDto();

            string baseUrl = Business.Constants.GetSubCountiesByCountyAndState;
            HttpClient client = new HttpClient();

            try
            {
                var counties = new List<County>();
                counties = _context.Set<County>().ToList();

                foreach (var county in counties)
                {
                    string query;
                    var cont = new FormUrlEncodedContent(
                        new Dictionary<string, string>()
                        {
                            { "stateCode", county.StateCode},
                            { "countyCode", county.Code},
                        });

                    query = cont.ReadAsStringAsync().Result;


                    HttpResponseMessage res = client.GetAsync(baseUrl + "?" + query).Result;
                    HttpContent content = res.Content;
                    var data = await content.ReadAsStringAsync();

                    if (content != null)
                    {
                        subCounties = JsonConvert.DeserializeObject<SubCountyListDto>(data);
                        _repositoryService.SaveSubCountiesData(subCounties, county.StateCode, county.Code);
                    }
                }

                _logger.LogInformation("Sub Counties Synced");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in Sub Counties Sync");
            }

            return subCounties;
        }

        public async Task<List<int>> GetRainfallYears()
        {
            var years = new List<int>();

            string baseUrl = Business.Constants.GetListOfAvailableRainfallYears;
            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage res = client.GetAsync(baseUrl).Result;
                HttpContent content = res.Content;
                var data = await content.ReadAsStringAsync();

                if (content != null)
                {
                    years = JsonConvert.DeserializeObject<List<int>>(data);
                    _repositoryService.SaveRainfallYearsData(years);
                }

                _logger.LogInformation("Rainfall Years Synced");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in Rainfall Years Sync");
            }

            return years;
        }
    }
}
