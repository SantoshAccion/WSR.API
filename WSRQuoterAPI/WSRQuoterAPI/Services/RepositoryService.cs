using AutoMapper;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WSRQuoterAPI.Models;
using WSRQuoterAPI.Models.USDADtos;
using WSRQuoterAPI.ViewModels;

namespace WSRQuoterAPI.Services
{
    public class RepositoryService : IRepositoryService
    {
        private InsuranceDBContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<RepositoryService> _logger;

        public RepositoryService(InsuranceDBContext context, IMapper mapper, ILogger<RepositoryService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public void SaveStatesData(StateListDto states)
        {
            try
            {
                var list = states.States.Select(x => _mapper.Map<State>(x)).ToList();

                var propToInclude = new List<string> { nameof(State.Name), nameof(State.Abbreviation) };
                var propToUpdate = new List<string> { nameof(State.Code) };
                var bulkConfig = new BulkConfig { PropertiesToInclude = propToInclude, UpdateByProperties = propToUpdate };

                using (var transaction = _context.Database.BeginTransaction())
                {
                    _context.BulkInsertOrUpdate(list, bulkConfig);
                    transaction.Commit();
                }

                _logger.LogInformation("States saved in database");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in saving States in database");
            }
        }

        public void SaveCountiesData(CountyListDto counties, string stateCode)
        {
            try
            {
                var list = counties.Counties.Select(x => _mapper.Map<County>(x)).ToList();

                foreach (var item in list)
                {
                    item.StateCode = stateCode;
                }

                var propToInclude = new List<string> { nameof(County.Name), nameof(County.StateCode) };
                var propToUpdate = new List<string> { nameof(County.Code), nameof(County.StateCode) };
                var bulkConfig = new BulkConfig { PropertiesToInclude = propToInclude, UpdateByProperties = propToUpdate };

                using (var transaction = _context.Database.BeginTransaction())
                {
                    _context.BulkInsertOrUpdate(list, bulkConfig);
                    transaction.Commit();
                }
                _logger.LogInformation("Counties saved in database");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in saving Counties in database");
            }
        }

        public void SaveSubCountiesData(SubCountyListDto subCounties, string stateCode, string countyCode)
        {
            try
            {
                var list = subCounties.SubCounties.Select(x => _mapper.Map<SubCounty>(x)).ToList();

                foreach (var item in list)
                {
                    item.StateCode = stateCode;
                    item.CountyCode = countyCode;
                }

                var propToInclude = new List<string> { nameof(SubCounty.GridId), nameof(SubCounty.StateCode), nameof(SubCounty.CountyCode) };
                var propToUpdate = new List<string> { nameof(SubCounty.StateCode), nameof(SubCounty.CountyCode) };
                var bulkConfig = new BulkConfig { PropertiesToInclude = propToInclude, UpdateByProperties = propToUpdate };

                using (var transaction = _context.Database.BeginTransaction())
                {
                    _context.BulkInsertOrUpdate(list, bulkConfig);
                    transaction.Commit();
                }
                _logger.LogInformation("Sub Counties saved in database");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in saving Sub Counties in database");
            }
        }

        public void SaveRainfallYearsData(List<int> years)
        {
            try
            {
                var list = years.Select(x => _mapper.Map<RainfallYear>(x)).OrderByDescending(x => x.Year).ToList();

                var propToInclude = new List<string> { nameof(RainfallYear.Year)};
                var propToUpdate = new List<string> { nameof(RainfallYear.Year) };
                var bulkConfig = new BulkConfig { PropertiesToInclude = propToInclude };

                using (var transaction = _context.Database.BeginTransaction())
                {
                    _context.Set<RainfallYear>().BatchDelete();
                    _context.BulkInsertOrUpdate(list, bulkConfig);
                    transaction.Commit();
                }

                _logger.LogInformation("Rainfall Years saved in database");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in saving Rainfall Years in database");
            }
        }

        public void SaveValidIntervalCodesData(IntervalCodeDto validIntervals, USDACode usdaCode, SubCounty subCounty, CoverageLevel coverageLevel)
        {
            try
            {
                var list = validIntervals.validatedIntervals.Select(x => _mapper.Map<ValidIntervalCode>(x)).ToList();

                foreach (var item in list)
                {
                    item.IntendedUse = usdaCode.IntendedUse;
                    item.IrrigationPractice = usdaCode.IrrigationPractice;
                    item.OrganicPractice = usdaCode.OrganicPractice;
                    item.StateCode = subCounty.StateCode;
                    item.CountyCode = subCounty.CountyCode;
                    item.GridId = subCounty.GridId;
                    item.CoveragePercentage = coverageLevel.CoveragePercentage;
                }

                var propToInclude = new List<string> { nameof(ValidIntervalCode.PremiumRate), nameof(ValidIntervalCode.IntervalIsValid) };
                var propToUpdate = new List<string> { nameof(ValidIntervalCode.StateCode), nameof(ValidIntervalCode.CountyCode), nameof(ValidIntervalCode.GridId), nameof(ValidIntervalCode.CoveragePercentage), nameof(ValidIntervalCode.IntervalCode), nameof(ValidIntervalCode.IntendedUse), nameof(ValidIntervalCode.IrrigationPractice), nameof(ValidIntervalCode.OrganicPractice) };
                var bulkConfig = new BulkConfig { PropertiesToInclude = propToInclude, UpdateByProperties = propToUpdate };

                using (var transaction = _context.Database.BeginTransaction())
                {
                    _context.BulkInsertOrUpdate(list, bulkConfig);
                    transaction.Commit();
                }
                _logger.LogInformation("Valid Interval Codes saved in database");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in saving Valid Interval Codes in database");
            }
        }

        public void SaveRainfallIndexesData(RainfallIndexDto rainfallIndex)
        {
            try
            {
                foreach (var index in rainfallIndex.HistoricalIndexRows)
                {
                    var list = index.HistoricalIndexDataColumns.Select(x => _mapper.Map<RainfallIndex>(x)).ToList();

                    var propToInclude = new List<string> { nameof(RainfallIndex.PercentOfNormal), nameof(RainfallIndex.IntervalMeasurement), nameof(RainfallIndex.AverageIntervalMeasurement), nameof(RainfallIndex.FilingStatusId) };
                    var propToUpdate = new List<string> { nameof(RainfallIndex.Year), nameof(RainfallIndex.IntervalCode), nameof(RainfallIndex.GridId) };
                    var bulkConfig = new BulkConfig { PropertiesToInclude = propToInclude, UpdateByProperties = propToUpdate };

                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        _context.BulkInsertOrUpdate(list, bulkConfig);
                        transaction.Commit();
                    }
                    _logger.LogInformation("Rainfall Indexes saved in database");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in saving Rainfall Indexes in database");
            }
        }

        public void SaveCountyBaseValuesData(PricingRatesDto pricingRates, USDACode usdaCode, SubCounty subCounty)
        {
            try
            {
                if (pricingRates.returnData.PricingRateSummary != null)
                {
                    var countyBaseValue = new CountyBaseValue();
                    var countyBaseValues = new List<CountyBaseValue>();

                    countyBaseValue.BaseValue = pricingRates.returnData.PricingRateSummary.CountyBaseValue;
                    countyBaseValue.IntendedUse = usdaCode.IntendedUse;
                    countyBaseValue.IrrigationPractice = usdaCode.IrrigationPractice;
                    countyBaseValue.OrganicPractice = usdaCode.OrganicPractice;
                    countyBaseValue.StateCode = subCounty.StateCode;
                    countyBaseValue.CountyCode = subCounty.CountyCode;
                    countyBaseValue.SampleYear = pricingRates.returnData.RainfallYear;

                    countyBaseValues.Add(countyBaseValue);

                    var propToInclude = new List<string> { nameof(CountyBaseValue.BaseValue) };
                    var propToUpdate = new List<string> { nameof(CountyBaseValue.IntendedUse), nameof(CountyBaseValue.IrrigationPractice), nameof(CountyBaseValue.OrganicPractice), nameof(CountyBaseValue.StateCode), nameof(CountyBaseValue.CountyCode), nameof(CountyBaseValue.SampleYear) };
                    var bulkConfig = new BulkConfig { PropertiesToInclude = propToInclude, UpdateByProperties = propToUpdate };

                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        _context.BulkInsertOrUpdate(countyBaseValues, bulkConfig);
                        transaction.Commit();
                    }
                    _logger.LogInformation("County Base Values saved in database");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured in saving County Base Values in database");
            }
        }
    }
}
