using System.Collections.Generic;
using System.Threading.Tasks;
using WSRQuoterAPI.Models;
using WSRQuoterAPI.Models.USDADtos;
using WSRQuoterAPI.ViewModels;

namespace WSRQuoterAPI.Services
{
    public interface IUSDASyncService
    {
        Task<StateListDto> GetStates();
        Task<CountyListDto> GetCounties();
        Task<SubCountyListDto> GetSubCounties();
        Task<List<int>> GetRainfallYears();
        Task<IntervalCodeDto> GetValidIntervalCodes();
        Task<RainfallIndexDto> GetRainfallIndexes();
        Task<PricingRatesDto> GetCountyBaseValues();
    }
}
