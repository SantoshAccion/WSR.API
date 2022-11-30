using System.ComponentModel.DataAnnotations.Schema;

namespace WSRQuoterAPI.Models
{
    public class ValidIntervalCode
    {
        public int Id { get; set; }
        public string IntendedUse { get; set; }
        public string IrrigationPractice { get; set; }
        public string OrganicPractice { get; set; }
        public string StateCode { get; set; }
        public string CountyCode { get; set; }
        public string GridId { get; set; }
        public int CoveragePercentage { get; set; }
        public string IntervalCode { get; set; }
        public double PremiumRate { get; set; }
        public bool IntervalIsValid { get; set; }
    }
}
