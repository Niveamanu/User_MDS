﻿using Microsoft.EntityFrameworkCore;
using UserMDS.Data;
using UserMDS.Models;
using UserMDS.Models.DTO;

namespace UserMDS.Repositories
{
    public class UserMDSRepository : IUserMDSRepository
    {
        private readonly UserMDSDbContext userMDSDbContext;
        public UserMDSRepository(UserMDSDbContext userMDSDbContext)
        {
            this.userMDSDbContext = userMDSDbContext;
        }

        public async Task<CompanyEmployeeBenefitsModel?> CreateCompanyEmployeeBenefitsAsync(CompanyEmployeeBenefitsModel companyEmployeeBenefitsModel)
        {
            var result = userMDSDbContext.Company_Employee_Benefits.FirstOrDefault(x => x.plant_unique == companyEmployeeBenefitsModel.plant_unique);
            if (result != null)
            {
                
                result.work_home_perc = companyEmployeeBenefitsModel.work_home_perc;
                result.insurance_perc = companyEmployeeBenefitsModel.insurance_perc;
                result.pto_perc = companyEmployeeBenefitsModel.pto_perc;
                result.adj_factor_perc = companyEmployeeBenefitsModel.adj_factor_perc;
                result.pr_tax_perc = companyEmployeeBenefitsModel.pr_tax_perc;
                result.tot_benefits_perc = companyEmployeeBenefitsModel.tot_benefits_perc;
                result.domain = "Labour";
                result.maintained_by = "Don Hoang";
                await userMDSDbContext.SaveChangesAsync();
                return result;  
            }
            companyEmployeeBenefitsModel.domain = "Labour";
            companyEmployeeBenefitsModel.maintained_by = "Don Hoang";
            await userMDSDbContext.AddAsync(companyEmployeeBenefitsModel);

            await userMDSDbContext.SaveChangesAsync();

            return companyEmployeeBenefitsModel;
        }

        public async Task<FreightMilesModel> CreateFreightMilesAsync(FreightMilesModel freightMilesModel)
        {
            //var result = userMDSDbContext.Freight_Miles.FirstOrDefault(x => x.prev_stop_zip == uKGProdCenterModel.Plant && x.Cost_Center == uKGProdCenterModel.Cost_Center && x.Shift == uKGProdCenterModel.Shift);
            //if (result != null)
            //{
            //    return null;
            //}
            freightMilesModel.domain = "Transportation";
            freightMilesModel.maintained_by = "Adam Bonser";
            await userMDSDbContext.AddAsync(freightMilesModel);

            await userMDSDbContext.SaveChangesAsync();
            return freightMilesModel;
        }

        public async Task<ManualKPIMetricsValueModel> CreateManualKPIMetricsValueAsync(ManualKPIMetricsValueModel manualKPIMetricsValueModel)
        {
            manualKPIMetricsValueModel.domain = "Transportation";
            manualKPIMetricsValueModel.maintained_by = "Adam Bonser";
            await userMDSDbContext.AddAsync(manualKPIMetricsValueModel);

            await userMDSDbContext.SaveChangesAsync();
            return manualKPIMetricsValueModel;
        }

        public async Task<RevisedCustShipToDetailsModel> CreateRevisedCustomerAsync(RevisedCustShipToDetailsModel revisedCustShipToDetailsModel)
        {
            revisedCustShipToDetailsModel.domain = "Transportation";
            revisedCustShipToDetailsModel.maintained_by = "Adam Bonser";
            await userMDSDbContext.AddAsync(revisedCustShipToDetailsModel);

            await userMDSDbContext.SaveChangesAsync();
            return revisedCustShipToDetailsModel;
        }

        public async Task<UKGProdCenterModel?> CreateUKGProdCenterAsync(UKGProdCenterModel uKGProdCenterModel)
        {
            var result = userMDSDbContext.UKG_Production_Centers.FirstOrDefault(x=>x.Plant==uKGProdCenterModel.Plant&&x.Cost_Center==uKGProdCenterModel.Cost_Center&&x.Shift==uKGProdCenterModel.Shift);
            if (result != null)
            {
                return null;
            }
            uKGProdCenterModel.Domain = "Labour";
            uKGProdCenterModel.Maintained_By = "Don Hoang";
            await userMDSDbContext.AddAsync(uKGProdCenterModel);

            await userMDSDbContext.SaveChangesAsync();
            return uKGProdCenterModel;
        }

    }
}
