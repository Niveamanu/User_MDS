using Microsoft.EntityFrameworkCore;
using UserMDS.Models;

namespace UserMDS.Data
{
    public class UserMDSDbContext : DbContext
    {
        public UserMDSDbContext(DbContextOptions<UserMDSDbContext> options) : base(options)
        {

        }
        
        public DbSet<UKGProdCenterModel> UKG_Production_Centers { get; set; }
        public DbSet<FreightMilesModel> Freight_Miles { get; set; }
        public DbSet<ManualKPIMetricsValueModel> Manual_KPI_Metrics_Value { get; set; }

        public DbSet<RevisedCustShipToDetailsModel> Revised_Customer_Ship_To_Details { get; set; }
        public DbSet<CompanyEmployeeBenefitsModel> Company_Employee_Benefits { get; set; }
        public DbSet<UserMaintenanceMasterDataModel> User_Maintenance_Master_Data { get; set; }
    }
}
