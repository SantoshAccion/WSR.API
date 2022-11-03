using System.ComponentModel.DataAnnotations;

namespace WSRQuoterAPI.Models
{
    public class PolicyHolder
    {
        [Key]
        public int PolicyHolderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PolicyId { get; set; }
    }
}
