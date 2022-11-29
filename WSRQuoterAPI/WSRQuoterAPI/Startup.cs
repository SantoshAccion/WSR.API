using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSRQuoterAPI.Models;
using WSRQuoterAPI.Services;

namespace WSRQuoterAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InsuranceDBContext>(x => x.UseSqlServer(Configuration.GetConnectionString("ConStr")));
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("HangfireConStr")));
            services.AddHangfireServer();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<IPolicyHolderService, PolicyHolderService>();
            services.AddScoped<IUSDASyncService, USDASyncService>();
            services.AddScoped<IRepositoryService, RepositoryService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseHangfireDashboard();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
