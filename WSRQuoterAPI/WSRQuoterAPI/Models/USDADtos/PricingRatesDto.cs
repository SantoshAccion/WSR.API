using System.Collections.Generic;

namespace WSRQuoterAPI.Models.USDADtos
{
    public class PricingRatesDto
    {
        public ReturnData returnData { get; set; }
    }

    public class PricingRateRow
    {
        public string IntervalCode { get; set; }
        public double PolicyProtection { get; set; }
        public double PremiumRate { get; set; }
        public double TotalPremium { get; set; }
        public double PremiumSubsidy { get; set; }
        public double ProducerPremium { get; set; }
        public double? PercentOfNormal { get; set; }
        public double? Indemnity { get; set; }
        public double? AverageIntervalMeasurement { get; set; }
        public double? IntervalMeasurement { get; set; }
        public int FilingStatusId { get; set; }
        public double PercentOfValue { get; set; }
    }

    public class PricingRateRowPerAcreSummary
    {
        public double TotalPremium { get; set; }
        public double PremiumSubsidy { get; set; }
        public double ProducerPremium { get; set; }
        public double Indemnity { get; set; }
    }

    public class PricingRateRowTotalSummary
    {
        public double TotalInsuredAcres { get; set; }
        public double PolicyProtection { get; set; }
        public double TotalPremium { get; set; }
        public double PremiumSubsidy { get; set; }
        public double ProducerPremium { get; set; }
        public double Indemnity { get; set; }
    }

    public class PricingRateSummary
    {
        public double CountyBaseValue { get; set; }
        public double ProtectionPerAcre { get; set; }
        public double TotalPolicyProtection { get; set; }
        public double TotalInsuredAcres { get; set; }
        public double SubsidyLevel { get; set; }
        public double MaximumAcrePercent { get; set; }
    }

    public class ReturnData
    {
        public List<PricingRateRow> PricingRateRows { get; set; }
        public PricingRateSummary PricingRateSummary { get; set; }
        public PricingRateRowPerAcreSummary PricingRateRowPerAcreSummary { get; set; }
        public PricingRateRowTotalSummary PricingRateRowTotalSummary { get; set; }
        public int RainfallYear { get; set; }
        public int NoaaGridId { get; set; }
    }
}
