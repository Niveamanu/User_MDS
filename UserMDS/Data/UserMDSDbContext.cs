using Microsoft.EntityFrameworkCore;
using UserMDS.Models;

namespace UserMDS.Data
{
    public class UserMDSDbContext : DbContext
    {
        public UserMDSDbContext(DbContextOptions<UserMDSDbContext> options) : base(options)
        {

        }
        public DbSet<AddUKGProdCenterModel> UKG_Production_Centers { get; set; }
    }
}
