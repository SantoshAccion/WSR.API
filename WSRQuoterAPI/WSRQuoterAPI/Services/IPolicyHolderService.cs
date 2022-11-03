using System.Collections.Generic;
using WSRQuoterAPI.Models;
using WSRQuoterAPI.ViewModels;

namespace WSRQuoterAPI.Services
{
    public interface IPolicyHolderService
    {
        /// <summary>
        /// get list of all PolicyHolders
        /// </summary>
        /// <returns></returns>
        List<PolicyHolder> GetPolicyHolderList();

        /// <summary>
        /// get PolicyHolder details by PolicyHolder id
        /// </summary>
        /// <param name="policyHolderId"></param>
        /// <returns></returns>
        PolicyHolder GetPolicyHolderDetailsById(int policyHolderId);

        /// <summary>
        ///  add edit PolicyHolder
        /// </summary>
        /// <param name="policyHolderModel"></param>
        /// <returns></returns>
        ResponseModel SavePolicyHolder(PolicyHolder policyHolderModel);


        /// <summary>
        /// delete PolicyHolder
        /// </summary>
        /// <param name="policyHolderId"></param>
        /// <returns></returns>
        ResponseModel DeletePolicyHolder(int policyHolderId);
    }
}
