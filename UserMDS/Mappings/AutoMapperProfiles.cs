using AutoMapper;
using UserMDS.Models;
using UserMDS.Models.DTO;

namespace UserMDS.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UKGProdCenterModel, AddUKGProdCenterDTO>().ReverseMap();
            CreateMap<CompanyEmployeeBenefitsModel, AddCompanyEmployeeBenefitsDTO>().ReverseMap();
            CreateMap<FreightMilesModel, AddFreightMilesDTO>().ReverseMap();
            CreateMap<RevisedCustShipToDetailsModel, AddRevisedCustToDetailsDTO>().ReverseMap();
            CreateMap<ManualKPIMetricsValueModel, AddManualKPIMtericsValueDTO>().ReverseMap();
        }
    }
}
