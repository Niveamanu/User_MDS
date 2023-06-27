using UserMDS.Models;
using UserMDS.Models.DTO;

namespace UserMDS.Repositories
{
    public interface IUserMDSRepository
    {
        Task<UKGProdCenterModel> CreateUKGProdCenterAsync(UKGProdCenterModel UKGProdCenterModel);
        Task<CompanyEmployeeBenefitsModel> CreateCompanyEmployeeBenefitsAsync(CompanyEmployeeBenefitsModel companyEmployeeBenefitsModel);
    }
}
