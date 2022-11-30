using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WSRQuoterAPI.Models;
using WSRQuoterAPI.Services;

namespace WSRQuoterAPI.Controllers
{
    [ApiController]
    [Route("USDASync")]
    public class USDASyncController : ControllerBase
    {
        IUSDASyncService _usdaSyncService;
        private readonly ILogger<USDASyncController> _logger;

        public USDASyncController(IUSDASyncService usdaSyncService, ILogger<USDASyncController> logger)
        {
            _usdaSyncService = usdaSyncService;
            _logger = logger;
        }

        [HttpGet]
        [Route("Sync")]
        public String Sync()
        {
            RecurringJob.AddOrUpdate(() => _usdaSyncService.GetStates(), Cron.Daily);
            RecurringJob.AddOrUpdate(() => _usdaSyncService.GetCounties(), Cron.Daily);
            RecurringJob.AddOrUpdate(() => _usdaSyncService.GetSubCounties(), Cron.Daily);
            RecurringJob.AddOrUpdate(() => _usdaSyncService.GetRainfallYears(), Cron.Daily);
            RecurringJob.AddOrUpdate(() => _usdaSyncService.GetValidIntervalCodes(), Cron.Daily);
            RecurringJob.AddOrUpdate(() => _usdaSyncService.GetRainfallIndexes(), Cron.Daily);
            RecurringJob.AddOrUpdate(() => _usdaSyncService.GetCountyBaseValues(), Cron.Daily);

            return "Synced!";
        }

        [HttpGet]
        [Route("SyncStates")]
        public String SyncStates()
        {
            _usdaSyncService.GetStates();

            return "States Synced!";
        }

        [HttpGet]
        [Route("SyncCounties")]
        public String SyncCounties()
        {
            _usdaSyncService.GetCounties();

            return "Counties Synced!";
        }

        [HttpGet]
        [Route("SyncSubCounties")]
        public String SyncSubCounties()
        {
            _usdaSyncService.GetSubCounties();

            return "Sub Counties Synced!";
        }

        [HttpGet]
        [Route("SyncRainfallYears")]
        public String SyncRainfallYears()
        {
            _usdaSyncService.GetRainfallYears();

            return "Rainfall Years Synced!";
        }

        [HttpGet]
        [Route("SyncValidIntervalCodes")]
        public String SyncValidIntervalCodes()
        {
            _usdaSyncService.GetValidIntervalCodes();

            return "Valid Interval Codes Synced!";
        }

        [HttpGet]
        [Route("SyncRainfallIndexes")]
        public String SyncRainfallIndexes()
        {
            _usdaSyncService.GetRainfallIndexes();

            return "Rainfall Indexes Synced!";
        }

        [HttpGet]
        [Route("SyncCountyBaseValues")]
        public String SyncCountyBaseValues()
        {
            _usdaSyncService.GetCountyBaseValues();

            return "County Base Values Synced!";
        }
    }
}
