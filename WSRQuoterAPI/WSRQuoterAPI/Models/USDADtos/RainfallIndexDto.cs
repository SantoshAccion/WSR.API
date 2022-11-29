using System.Collections.Generic;

namespace WSRQuoterAPI.Models.USDADtos
{
    public class RainfallIndexDto
    {
        public List<HistoricalIndexRow> HistoricalIndexRows { get; set; }
    }

    public class HistoricalIndexRow
    {
        public int Year { get; set; }
        public List<HistoricalIndexDataColumn> HistoricalIndexDataColumns { get; set; }
    }

    public class HistoricalIndexDataColumn
    {
        public int Year { get; set; }
        public string IntervalCode { get; set; }
        public double PercentOfNormal { get; set; }
        public double IntervalMeasurement { get; set; }
        public double AverageIntervalMeasurement { get; set; }
        public int GridId { get; set; }
        public int FilingStatusId { get; set; }
    }
}
