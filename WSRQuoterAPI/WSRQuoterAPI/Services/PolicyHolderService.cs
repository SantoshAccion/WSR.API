using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WSRQuoterAPI.Models;
using WSRQuoterAPI.ViewModels;

namespace WSRQuoterAPI.Services
{
    public class PolicyHolderService : IPolicyHolderService
    {
        private InsuranceDBContext _context;
        private readonly ILogger<PolicyHolderService> _logger;

        public PolicyHolderService(InsuranceDBContext context, ILogger<PolicyHolderService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public PolicyHolder GetPolicyHolderDetailsById(int policyHolderId)
        {
            var policyHolder = new PolicyHolder();

            try
            {
                _logger.LogInformation("GetPolicyHolderDetailsById called");

                policyHolder = _context.Find<PolicyHolder>(policyHolderId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in GetPolicyHolderDetailsById");
            }

            return policyHolder;
        }

        public List<PolicyHolder> GetPolicyHolderList()
        {
            var policyHolderList = new List<PolicyHolder>();

            try
            {
                _logger.LogInformation("GetPolicyHolderList called");

                policyHolderList = _context.Set<PolicyHolder>().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in GetPolicyHolderList");
            }

            return policyHolderList;
        }

        public ResponseModel SavePolicyHolder(PolicyHolder policyHolderModel)
        {
            ResponseModel model = new ResponseModel();

            try
            {
                _logger.LogInformation("SavePolicyHolder called");

                PolicyHolder _temp = GetPolicyHolderDetailsById(policyHolderModel.PolicyHolderId);

                if (_temp != null)
                {
                    _temp.FirstName = policyHolderModel.FirstName;
                    _temp.LastName = policyHolderModel.LastName;

                    _context.Update<PolicyHolder>(_temp);
                    
                    model.Messsage = "PolicyHolder Updated Successfully";
                }
                else
                {
                    _context.Add<PolicyHolder>(policyHolderModel);
                    model.Messsage = "PolicyHolder Inserted Successfully";
                }

                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;

                _logger.LogError(ex, "Error occured in SavePolicyHolder");
            }

            return model;
        }

        public ResponseModel DeletePolicyHolder(int policyHolderId)
        {
            ResponseModel model = new ResponseModel();
            
            try
            {
                _logger.LogInformation("DeletePolicyHolder called");

                PolicyHolder _temp = GetPolicyHolderDetailsById(policyHolderId);
                
                if (_temp != null)
                {
                    _context.Remove<PolicyHolder>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "PolicyHolder Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "PolicyHolder Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;

                _logger.LogError(ex, "Error occured in DeletePolicyHolder");
            }

            return model;
        }

    }
}
