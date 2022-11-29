using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WSRQuoterAPI.Models;
using WSRQuoterAPI.Models.USDADtos;
using WSRQuoterAPI.ViewModels;

namespace WSRQuoterAPI.Services
{
    public class AgentService : IAgentService
    {
        private InsuranceDBContext _context;
        private readonly ILogger<AgentService> _logger;

        public AgentService(InsuranceDBContext context, ILogger<AgentService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Agent GetAgentDetailsById(int agentId)
        {
            var agent = new Agent();

            try
            {
                _logger.LogInformation("GetAgentDetailsById called");

                agent = _context.Find<Agent>(agentId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in GetAgentDetailsById");
            }

            return agent;
        }

        public List<Agent> GetAgentList()
        {
            var agentList = new List<Agent>();

            try
            {
                _logger.LogInformation("GetAgentList called");

                agentList = _context.Set<Agent>().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in GetAgentList");
            }

            return agentList;
        }

        public ResponseModel SaveAgent(Agent agentModel)
        {
            ResponseModel model = new ResponseModel();

            try
            {
                _logger.LogInformation("SaveAgent called");

                Agent _temp = GetAgentDetailsById(agentModel.AgentId);

                if (_temp != null)
                {
                    _temp.AgentFirstName = agentModel.AgentFirstName;
                    _temp.AgentLastName = agentModel.AgentLastName;

                    _context.Update<Agent>(_temp);
                    
                    model.Messsage = "Agent Updated Successfully";
                }
                else
                {
                    _context.Add<Agent>(agentModel);
                    model.Messsage = "Agent Inserted Successfully";
                }

                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;

                _logger.LogError(ex, "Error occured in SaveAgent");
            }

            return model;
        }

        public ResponseModel DeleteAgent(int agentId)
        {
            ResponseModel model = new ResponseModel();
            
            try
            {
                _logger.LogInformation("DeleteAgent called");

                Agent _temp = GetAgentDetailsById(agentId);
                
                if (_temp != null)
                {
                    _context.Remove<Agent>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Agent Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Agent Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;

                _logger.LogError(ex, "Error occured in DeleteAgent");
            }

            return model;
        }
    }
}
