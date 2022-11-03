using Microsoft.EntityFrameworkCore;

namespace WSRQuoterAPI.Models
{
    public class InsuranceDBContext : DbContext
    {
        public InsuranceDBContext(DbContextOptions options) : base(options) { }
        DbSet<Agent> Agents
        {
            get;
            set;
        }
        DbSet<PolicyHolder> PolicyHolders
        {
            get;
            set;
        }
    }
}
