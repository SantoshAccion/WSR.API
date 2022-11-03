using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using WSRQuoterAPI.Models;
using WSRQuoterAPI.Services;

namespace WSRQuoterAPI.Controllers
{
    [ApiController]
    [Route("PolicyHolder")]
    public class PolicyHolderController : ControllerBase
    {
        IPolicyHolderService _policyHolderService;
        private readonly ILogger<PolicyHolderController> _logger;

        public PolicyHolderController(IPolicyHolderService policyHolderService, ILogger<PolicyHolderController> logger)
        {
            _policyHolderService = policyHolderService;
            _logger = logger;
        }

        /// <summary>
        /// get all policyHolders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AllPolicyHolders")]
        public IActionResult GetAllPolicyHolders()
        {
            try
            {
                _logger.LogInformation("GetAllPolicyHolders called");

                var policyHolders = _policyHolderService.GetPolicyHolderList();
                if (policyHolders == null)
                    return NotFound();
                
                return Ok(policyHolders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in GetAllPolicyHolders");
                return BadRequest();
            }
        }

        /// <summary>
        /// get policyHolder details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PolicyHolder")]
        public IActionResult GetPolicyHolderById(int id)
        {
            try
            {
                _logger.LogInformation("GetPolicyHolderById called");

                var policyHolder = _policyHolderService.GetPolicyHolderDetailsById(id);
                if (policyHolder == null)
                    return NotFound();
                
                return Ok(policyHolder);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in GetPolicyHolderById");
                return BadRequest();
            }
        }

        /// <summary>
        /// save policyHolder
        /// </summary>
        /// <param name="policyHolderModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Save")]
        public IActionResult SavePolicyHolder(PolicyHolder policyHolderModel)
        {
            try
            {
                _logger.LogInformation("SavePolicyHolder called");

                var model = _policyHolderService.SavePolicyHolder(policyHolderModel);
                
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in SavePolicyHolder");
                return BadRequest();
            }
        }

        /// <summary>
        /// delete policyHolder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeletePolicyHolder(int id)
        {
            try
            {
                _logger.LogInformation("DeletePolicyHolder called");

                var model = _policyHolderService.DeletePolicyHolder(id);
                
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in DeletePolicyHolder");
                return BadRequest();
            }
        }
    }
}
