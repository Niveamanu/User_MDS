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
        public async Task<UKGProdCenterModel> CreateUKGProdCenterAsync(UKGProdCenterModel uKGProdCenterModel)
        {
             
            await userMDSDbContext.AddAsync(uKGProdCenterModel);

            await userMDSDbContext.SaveChangesAsync();
            return uKGProdCenterModel;
        }
    }
}
