using UserMDS.Models;
using UserMDS.Models.DTO;

namespace UserMDS.Repositories
{
    public interface IUserMDSRepository
    {
        Task<UKGProdCenterModel> CreateUKGProdCenterAsync(UKGProdCenterModel UKGProdCenterModel);
        Task<CompanyEmployeeBenefitsModel> CreateCompanyEmployeeBenefitsAsync(CompanyEmployeeBenefitsModel companyEmployeeBenefitsModel);

        Task<FreightMilesModel> CreateFreightMilesAsync(FreightMilesModel freightMilesModel);
        Task<RevisedCustShipToDetailsModel> CreateRevisedCustomerAsync(RevisedCustShipToDetailsModel revisedCustShipToDetailsModel);

        Task<ManualKPIMetricsValueModel> CreateManualKPIMetricsValueAsync(ManualKPIMetricsValueModel manualKPIMetricsValueModel);


    }
}
