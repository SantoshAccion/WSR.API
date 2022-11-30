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
        DbSet<USDACode> USDACodes
        {
            get;
            set;
        }
        DbSet<IntervalCode> IntervalCodes
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
        DbSet<ValidIntervalCode> ValidIntervalCodes
        {
            get;
            set;
        }
        DbSet<CoverageLevel> CoverageLevels
        {
            get;
            set;
        }
        DbSet<RainfallIndex> RainfallIndices
        {
            get;
            set;
        }
        DbSet<CountyBaseValue> CountyBaseValues
        {
            get;
            set;
        }
    }
}
