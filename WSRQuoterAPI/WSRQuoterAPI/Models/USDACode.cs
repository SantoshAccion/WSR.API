using System.Collections.Generic;
using WSRQuoterAPI.Models.USDADtos;

namespace WSRQuoterAPI.Models
{
    public class USDACode
    {
        public int Id { get; set; }
        public string IntendedUse { get; set; }
        public string IrrigationPractice { get; set; }
        public string OrganicPractice { get; set; }
    }
}
