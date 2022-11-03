using System.ComponentModel.DataAnnotations;

namespace WSRQuoterAPI.Models
{
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }
        public string AgentFirstName { get; set; }
        public string AgentLastName { get; set; }
    }
}
