using Microsoft.EntityFrameworkCore;
using WSRQuoterAPI.Models.USDADtos;

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
        DbSet<State> States
        {
            get;
            set;
        }
        DbSet<County> Counties
        {
            get;
            set;
        }
        DbSet<SubCounty> SubCounties
        {
            get;
            set;
        }
        DbSet<RainfallYear> RainfallYears
        {
            get;
            set;
        }
    }
}
