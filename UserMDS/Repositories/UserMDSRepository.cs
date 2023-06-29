using Microsoft.EntityFrameworkCore;
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

        public async Task<CompanyEmployeeBenefitsModel> CreateCompanyEmployeeBenefitsAsync(CompanyEmployeeBenefitsModel companyEmployeeBenefitsModel)
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
                result.modified_date= DateTime.Now;
                await userMDSDbContext.SaveChangesAsync();
                return result;  
            }
            companyEmployeeBenefitsModel.domain = "Labour";
            companyEmployeeBenefitsModel.maintained_by = "Don Hoang";
            companyEmployeeBenefitsModel.created_date = DateTime.Now;
            await userMDSDbContext.AddAsync(companyEmployeeBenefitsModel);

            await userMDSDbContext.SaveChangesAsync();

            return companyEmployeeBenefitsModel;
        }

        public async Task<FreightMilesModel> CreateFreightMilesAsync(FreightMilesModel freightMilesModel)
        {
            var result = userMDSDbContext.Freight_Miles.FirstOrDefault(x => x.prev_stop_zip == freightMilesModel.prev_stop_zip && x.next_stop_zip == freightMilesModel.next_stop_zip);
            if (result != null)
            {
                 result.Index = freightMilesModel.Index;
                 result.miles= freightMilesModel.miles;
                 result.mileage_src = freightMilesModel.mileage_src;
                 result.first= freightMilesModel.first;
                 result.second= freightMilesModel.second;
                 result.revised= freightMilesModel.revised;
                 result.domain = "Transportation";
                 result.maintained_by = "Adam Bonser";
                 result.modified_date= DateTime.Now;
                await userMDSDbContext.SaveChangesAsync();
                return result;  

            }
            freightMilesModel.domain = "Transportation";
            freightMilesModel.maintained_by = "Adam Bonser";
            freightMilesModel.created_date= DateTime.Now;
            await userMDSDbContext.AddAsync(freightMilesModel);

            await userMDSDbContext.SaveChangesAsync();
            return freightMilesModel;
        }

        public async Task<ManualKPIMetricsValueModel> CreateManualKPIMetricsValueAsync(ManualKPIMetricsValueModel manualKPIMetricsValueModel)
        {
            var result = userMDSDbContext.Manual_KPI_Metrics_Value.FirstOrDefault(x => x.effective_date_from == manualKPIMetricsValueModel.effective_date_from && x.business_unit == manualKPIMetricsValueModel.business_unit && x.lhl_loc==manualKPIMetricsValueModel.lhl_loc);
            if (result != null)
            {
                result.weekly_overhead_pnw_eq_fsc_noc = manualKPIMetricsValueModel.weekly_overhead_pnw_eq_fsc_noc;
                result.weekly_overhead_other = manualKPIMetricsValueModel.weekly_overhead_other;
                result.weekly_overhead_projection = manualKPIMetricsValueModel.weekly_overhead_projection;
                result.domain = "Transportation";
                result.maintained_by = "Adam Bonser";
                result.modified_date = DateTime.Now;
                await userMDSDbContext.SaveChangesAsync();
                return result;
            }
            manualKPIMetricsValueModel.domain = "Transportation";
            manualKPIMetricsValueModel.maintained_by = "Adam Bonser";
            manualKPIMetricsValueModel.created_date= DateTime.Now;
            await userMDSDbContext.AddAsync(manualKPIMetricsValueModel);

            await userMDSDbContext.SaveChangesAsync();
            return manualKPIMetricsValueModel;
        }

        public async Task<RevisedCustShipToDetailsModel> CreateRevisedCustomerAsync(RevisedCustShipToDetailsModel revisedCustShipToDetailsModel)
        {
            var result = userMDSDbContext.Revised_Customer_Ship_To_Details.FirstOrDefault(x => x.business_unit == revisedCustShipToDetailsModel.business_unit && x.cust_no == revisedCustShipToDetailsModel.cust_no);
            if (result != null)
            {
                result.cust_no_revised = revisedCustShipToDetailsModel.cust_no_revised;
                result.domain = "Transportation";
                result.maintained_by = "Adam Bonser";
                result.modified_date = DateTime.Now;
                await userMDSDbContext.SaveChangesAsync();
                return result;
            }
            revisedCustShipToDetailsModel.domain = "Transportation";
            revisedCustShipToDetailsModel.maintained_by = "Adam Bonser";
            revisedCustShipToDetailsModel.created_date = DateTime.Now;
            await userMDSDbContext.AddAsync(revisedCustShipToDetailsModel);
            await userMDSDbContext.SaveChangesAsync();
            return revisedCustShipToDetailsModel;
        }

        public async Task<UKGProdCenterModel> CreateUKGProdCenterAsync(UKGProdCenterModel uKGProdCenterModel)
        {
            var result = userMDSDbContext.UKG_Production_Centers.FirstOrDefault(x=>x.Plant==uKGProdCenterModel.Plant&&x.Cost_Center==uKGProdCenterModel.Cost_Center&&x.Shift==uKGProdCenterModel.Shift);
            if (result != null)
            {
                result.Modified_Date = DateTime.Now;
                return result;
            }
            uKGProdCenterModel.Domain = "Labour";
            uKGProdCenterModel.Maintained_By = "Don Hoang";
            uKGProdCenterModel.Created_Date= DateTime.Now;
            await userMDSDbContext.AddAsync(uKGProdCenterModel);

            await userMDSDbContext.SaveChangesAsync();
            return uKGProdCenterModel;
        }

    }
}
