namespace WSRQuoterAPI.Models
{
    public class CountyBaseValue
    {
        public int Id { get; set; }
        public double BaseValue { get; set; }
        public string IntendedUse { get; set; }
        public string IrrigationPractice { get; set; }
        public string OrganicPractice { get; set; }
        public string StateCode { get; set; }
        public string CountyCode { get; set; }
        public int SampleYear { get; set; }
    }
}
