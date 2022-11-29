using System.Collections.Generic;

namespace WSRQuoterAPI.Models.USDADtos
{
    public class IntervalCodeDto
    {
        public List<ValidatedInterval> validatedIntervals { get; set; }
    }

    public class ValidatedInterval
    {
        public string IntervalCode { get; set; }
        public double PremiumRate { get; set; }
        public bool IntervalIsValid { get; set; }
    }
}
