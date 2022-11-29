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
        [Route("SyncIntervalCodes")]
        public String SyncIntervalCodes()
        {
            _usdaSyncService.GetIntervalCodes();

            return "Interval Codes Synced!";
        }

        [HttpGet]
        [Route("SyncRainfallIndexes")]
        public String SyncRainfallIndexes()
        {
            _usdaSyncService.GetRainfallIndexes();

            return "Rainfall Indexes Synced!";
        }
    }
}
