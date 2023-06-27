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

        public DbSet<CompanyEmployeeBenefitsModel> Company_Employee_Benefits { get; set; }
        public DbSet<UserMaintenanceMasterDataModel> User_Maintenance_Master_Data { get; set; }
    }
}
