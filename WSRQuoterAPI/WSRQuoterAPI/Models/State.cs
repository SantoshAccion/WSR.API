using System.Collections.Generic;
using WSRQuoterAPI.Models.USDADtos;

namespace WSRQuoterAPI.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Abbreviation { get; set; }
    }
}
