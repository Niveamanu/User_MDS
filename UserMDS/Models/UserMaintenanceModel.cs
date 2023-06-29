using UserMDS.Models.DTO;

namespace UserMDS.Models
{
    public class UserMaintenanceModel
    {
        public List<UKGProdCenterModel> UKGProdCenters { get; set; }
        public List<CompanyEmployeeBenefitsModel> CompanyEmployeesBenefits { get; set;}

        public List<FreightMilesModel> FreightMiles { get; set;}
        public List<RevisedCustShipToDetailsModel> revisedCustShipToDetails { get; set; }
        public List<ManualKPIMetricsValueModel> manualKPIMetricsValues { get; set; }
    }
}
