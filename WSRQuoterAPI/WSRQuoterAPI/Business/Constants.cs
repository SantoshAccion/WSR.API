using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;

namespace WSRQuoterAPI.Business
{
    public static class Constants
    {
        public const string GetStates = "https://public-rma.fpac.usda.gov/apps/PrfWebApi/PrfExternalStates/GetStates";
        public const string GetCountiesByState = "https://public-rma.fpac.usda.gov/apps/PrfWebApi/PrfExternalStates/GetCountiesByState";
        public const string GetSubCountiesByCountyAndState = "https://public-rma.fpac.usda.gov/apps/PrfWebApi/PrfExternalStates/GetSubCountiesByCountyAndState";
        public const string GetListOfAvailableRainfallYears = "https://public-rma.fpac.usda.gov/apps/PrfWebApi/PrfExternalIndexes/GetListOfAvailableRainfallYears";
        public const string GetIndexValues = "https://public-rma.fpac.usda.gov/apps/PrfWebApi/PrfExternalIndexes/GetIndexValues";
        public const string GetCountiesAndStatesFromGridId = "https://public-rma.fpac.usda.gov/apps/PrfWebApi/PrfExternalStates/GetCountiesAndStatesFromGridId";
        public const string GetValidIntervalCodes = "https://public-rma.fpac.usda.gov/apps/PrfWebApi/PrfExternalIntervalCodes/GetValidIntervalCodes";
        public const string GetMaxAcrePercentage = "https://public-rma.fpac.usda.gov/apps/PrfWebApi/PrfExternalMaxAcrePercentage/GetMaxAcrePercentage";
        public const string GetPricingRates = "https://public-rma.fpac.usda.gov/apps/PrfWebApi/PrfExternalPricingRates/GetPricingRates";
        public const string GetEstimatedIndemnityValues = "https://public-rma.fpac.usda.gov/apps/PrfWebApi/PrfExternalEstimatedIndemnities/GetEstimatedIndemnityValues";
        public const string GetContinentalUsGridList = "https://public-rma.fpac.usda.gov/apps/PrfWebApi/PrfExternalNoaaGrids/GetContinentalUsGridList";
    }

    public static class IntendedUseCode
    {
        public const string Grazing = "007";
        public const string Haying = "030";
    }
}
