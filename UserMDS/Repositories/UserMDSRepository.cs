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
                await userMDSDbContext.SaveChangesAsync();
                return result;  
            }
            await userMDSDbContext.AddAsync(companyEmployeeBenefitsModel);

            await userMDSDbContext.SaveChangesAsync();
            return companyEmployeeBenefitsModel;
        }

        public async Task<UKGProdCenterModel?> CreateUKGProdCenterAsync(UKGProdCenterModel uKGProdCenterModel)
        {
            var result = userMDSDbContext.UKG_Production_Centers.FirstOrDefault(x=>x.Plant==uKGProdCenterModel.Plant&&x.Cost_Center==uKGProdCenterModel.Cost_Center&&x.Shift==uKGProdCenterModel.Shift);
            if (result != null)
            {
                return null;
            }
            await userMDSDbContext.AddAsync(uKGProdCenterModel);

            await userMDSDbContext.SaveChangesAsync();
            return uKGProdCenterModel;
        }

    }
}
