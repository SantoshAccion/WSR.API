using System.Collections.Generic;
using WSRQuoterAPI.Models;
using WSRQuoterAPI.ViewModels;

namespace WSRQuoterAPI.Services
{
    public interface IAgentService
    {
        /// <summary>
        /// get list of all agents
        /// </summary>
        /// <returns></returns>
        List<Agent> GetAgentList();

        /// <summary>
        /// get agent details by agent id
        /// </summary>
        /// <param name="agentId"></param>
        /// <returns></returns>
        Agent GetAgentDetailsById(int agentId);

        /// <summary>
        ///  add edit agent
        /// </summary>
        /// <param name="agentModel"></param>
        /// <returns></returns>
        ResponseModel SaveAgent(Agent agentModel);


        /// <summary>
        /// delete agents
        /// </summary>
        /// <param name="agentId"></param>
        /// <returns></returns>
        ResponseModel DeleteAgent(int agentId);
    }
}
