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

        public async Task<IntervalCodeDto> GetValidIntervalCodes()
        {
            var validIntervals = new IntervalCodeDto();

            string baseUrl = Business.Constants.GetValidIntervalCodes;
            HttpClient client = new HttpClient();

            try
            {
                var subCounties = new List<SubCounty>();
                subCounties = _context.Set<SubCounty>().ToList();
                var usdaCodes = new List<USDACode>();
                usdaCodes = _context.Set<USDACode>().ToList();
                var coverageLevels = new List<CoverageLevel>();
                coverageLevels = _context.Set<CoverageLevel>().ToList();

                foreach (var usdaCode in usdaCodes)
                {
                    foreach (var subCounty in subCounties)
                    {
                        foreach (var coverageLevel in coverageLevels)
                        {
                            string query;
                            var cont = new FormUrlEncodedContent(
                                new Dictionary<string, string>()
                                {
                                    { "intervalType", "BiMonthly"},
                                    { "irrigationPracticeCode", usdaCode.IrrigationPractice},
                                    { "organicPracticeCode", usdaCode.OrganicPractice},
                                    { "intendedUseCode", usdaCode.IntendedUse},
                                    { "stateCode", subCounty.StateCode},
                                    { "countyCode", subCounty.CountyCode},
                                    { "gridId", subCounty.GridId},
                                    { "coverageLevelPercent", coverageLevel.CoveragePercentage.ToString()},
                                });

                            query = cont.ReadAsStringAsync().Result;


                            HttpResponseMessage res = client.GetAsync(baseUrl + "?" + query).Result;
                            HttpContent content = res.Content;
                            var data = await content.ReadAsStringAsync();

                            if (content != null)
                            {
                                validIntervals = JsonConvert.DeserializeObject<IntervalCodeDto>(data);
                                if (validIntervals.validatedIntervals != null)
                                    _repositoryService.SaveValidIntervalCodesData(validIntervals, usdaCode, subCounty, coverageLevel);
                            }
                        }
                    }
                }

                _logger.LogInformation("Valid Interval Codes Synced");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in Valid Interval Codes Sync");
            }

            return validIntervals;
        }

        public async Task<RainfallIndexDto> GetRainfallIndexes()
        {
            var rainfallIndex = new RainfallIndexDto();

            string baseUrl = Business.Constants.GetIndexValues;
            HttpClient client = new HttpClient();

            try
            {
                var minYear = new RainfallYear();
                minYear = _context.Set<RainfallYear>().OrderBy(x => x.Year).FirstOrDefault();
                var maxYear = new RainfallYear();
                maxYear = _context.Set<RainfallYear>().OrderBy(x => x.Year).LastOrDefault();
                var subCounties = new List<string>();
                subCounties = _context.Set<SubCounty>().Select(x => x.GridId).Distinct().OrderBy(x => x).ToList();

                foreach (var subCounty in subCounties)
                {
                    string query;
                    var cont = new FormUrlEncodedContent(
                        new Dictionary<string, string>()
                        {
                            { "intervalType", "BiMonthly"},
                            { "sampleYearMinimum", minYear.Year.ToString()},
                            { "sampleYearMaximum", maxYear.Year.ToString()},
                            { "gridId", subCounty},
                        });

                    query = cont.ReadAsStringAsync().Result;


                    HttpResponseMessage res = client.GetAsync(baseUrl + "?" + query).Result;
                    HttpContent content = res.Content;
                    var data = await content.ReadAsStringAsync();

                    if (content != null)
                    {
                        rainfallIndex = JsonConvert.DeserializeObject<RainfallIndexDto>(data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                        if (rainfallIndex.HistoricalIndexRows != null)
                            _repositoryService.SaveRainfallIndexesData(rainfallIndex);
                    }
                }

                _logger.LogInformation("Rainfall Indexes Synced");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in Rainfall Indexes Sync");
            }

            return rainfallIndex;
        }

        public async Task<PricingRatesDto> GetCountyBaseValues()
        {
            var pricingRates = new PricingRatesDto();

            string baseUrl = Business.Constants.GetPricingRates;
            HttpClient client = new HttpClient();

            try
            {
                var subCounties = new List<SubCounty>();
                subCounties = _context.Set<SubCounty>().ToList();
                var usdaCodes = new List<USDACode>();
                usdaCodes = _context.Set<USDACode>().ToList();

                foreach (var usdaCode in usdaCodes)
                {
                    foreach (var subCounty in subCounties)
                    {
                        string query;
                        var cont = new FormUrlEncodedContent(
                            new Dictionary<string, string>()
                            {
                                { "intervalType", "BiMonthly"},
                                { "irrigationPracticeCode", usdaCode.IrrigationPractice},
                                { "organicPracticeCode", usdaCode.OrganicPractice},
                                { "intendedUseCode", usdaCode.IntendedUse},
                                { "stateCode", subCounty.StateCode},
                                { "countyCode", subCounty.CountyCode},
                                { "gridId", subCounty.GridId},
                                { "coverageLevelPercent", "90"},
                                { "productivityFactor", "100"},
                                { "insurableInterest", "100"},
                                { "insuredAcres", "100"},
                                { "sampleYear", DateTime.Now.Year.ToString()},
                                { "intervalPercentOfValues", "[25,0,25,0,25,0,0,0,25,0,0]"},
                            });

                        query = cont.ReadAsStringAsync().Result;

                        HttpResponseMessage res = client.GetAsync(baseUrl + "?" + query).Result;
                        HttpContent content = res.Content;
                        var data = await content.ReadAsStringAsync();

                        if (content != null)
                        {
                            pricingRates = JsonConvert.DeserializeObject<PricingRatesDto>(data);
                            if (pricingRates.returnData.PricingRateSummary != null)
                                _repositoryService.SaveCountyBaseValuesData(pricingRates, usdaCode, subCounty);
                        }
                    }
                }

                _logger.LogInformation("County Base Values Synced");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in County Base Values Sync");
            }

            return pricingRates;
        }
    }
}
