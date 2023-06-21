using UserMDS.Data;
using UserMDS.Models;

namespace UserMDS.Repositories
{
    public class UserMDSRepository : IUserMDSRepository
    {
        private readonly UserMDSDbContext userMDSDbContext;
        public UserMDSRepository(UserMDSDbContext userMDSDbContext)
        {
            this.userMDSDbContext = userMDSDbContext;
        }
        public async Task<AddUKGProdCenterModel> CreateUKGProdCenterAsync(AddUKGProdCenterModel uKGProdCenterModel)
        {
            uKGProdCenterModel.Updated_Date = DateTime.Now;
            await userMDSDbContext.AddAsync(uKGProdCenterModel);
        
            await userMDSDbContext.SaveChangesAsync();
            return uKGProdCenterModel;
        }
    }
}
