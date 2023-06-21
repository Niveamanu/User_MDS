using UserMDS.Models;

namespace UserMDS.Repositories
{
    public interface IUserMDSRepository
    {
        Task<AddUKGProdCenterModel> CreateUKGProdCenterAsync(AddUKGProdCenterModel addUKGProdCenterModel);
    }
}
