using MyGym.Models;

namespace MyGym.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAll();
        Task<UserModel> GetById(int id);
        Task<UserModel> Create(UserModel model);
        Task<UserModel> Update(UserModel model, string id);
        Task<UserModel> Delete(string id);
    }
}
