using System.ComponentModel.DataAnnotations.Schema;

namespace WSRQuoterAPI.Models.USDADtos
{
    public class SubCounty
    {
        public int Id { get; set; }
        public string GridId { get; set; }

        [ForeignKey("State")]
        public string StateCode { get; set; }

        [ForeignKey("County")]
        public string CountyCode { get; set; }
    }
}
