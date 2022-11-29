using System.Collections.Generic;
using WSRQuoterAPI.Models;
using WSRQuoterAPI.Models.USDADtos;
using WSRQuoterAPI.ViewModels;

namespace WSRQuoterAPI.Services
{
    public interface IRepositoryService
    {
        void SaveStatesData(StateListDto states);
        void SaveCountiesData(CountyListDto counties, string stateCode);
        void SaveSubCountiesData(SubCountyListDto subCounties, string stateCode, string countyCode);
        void SaveRainfallYearsData(List<int> years);
    }
}
