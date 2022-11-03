using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using WSRQuoterAPI.Models;
using WSRQuoterAPI.Services;

namespace WSRQuoterAPI.Controllers
{
    [ApiController]
    [Route("Agent")]
    public class AgentController : ControllerBase
    {
        IAgentService _agentService;
        private readonly ILogger<AgentController> _logger;

        public AgentController(IAgentService agentService, ILogger<AgentController> logger)
        {
            _agentService = agentService;
            _logger = logger;
        }

        /// <summary>
        /// get all agents
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AllAgents")]
        public IActionResult GetAllAgents()
        {
            try
            {
                _logger.LogInformation("GetAllAgents called");

                var agents = _agentService.GetAgentList();
                if (agents == null)
                    return NotFound();
                
                return Ok(agents);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in GetAllAgents");
                return BadRequest();
            }
        }

        /// <summary>
        /// get agent details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Agent")]
        public IActionResult GetAgentById(int id)
        {
            try
            {
                _logger.LogInformation("GetAgentById called");

                var agent = _agentService.GetAgentDetailsById(id);
                if (agent == null)
                    return NotFound();
                
                return Ok(agent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in GetAgentById");
                return BadRequest();
            }
        }

        /// <summary>
        /// save agent
        /// </summary>
        /// <param name="agentModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Save")]
        public IActionResult SaveAgent(Agent agentModel)
        {
            try
            {
                _logger.LogInformation("SaveAgent called");

                var model = _agentService.SaveAgent(agentModel);
                
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in SaveAgent");
                return BadRequest();
            }
        }

        /// <summary>
        /// delete agent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteAgent(int id)
        {
            try
            {
                _logger.LogInformation("DeleteAgent called");

                var model = _agentService.DeleteAgent(id);
                
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in DeleteAgent");
                return BadRequest();
            }
        }
    }
}
