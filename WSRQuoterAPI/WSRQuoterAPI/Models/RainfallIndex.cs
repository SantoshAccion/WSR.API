namespace WSRQuoterAPI.Models
{
    public class RainfallIndex
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string IntervalCode { get; set; }
        public double? PercentOfNormal { get; set; }
        public double? IntervalMeasurement { get; set; }
        public double? AverageIntervalMeasurement { get; set; }
        public int GridId { get; set; }
        public int FilingStatusId { get; set; }
    }
}
