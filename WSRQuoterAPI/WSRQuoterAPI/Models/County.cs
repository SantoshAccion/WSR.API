using System.ComponentModel.DataAnnotations.Schema;

namespace WSRQuoterAPI.Models.USDADtos
{
    public class County
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        [ForeignKey("State")]
        public string StateCode { get; set; }
    }
}
