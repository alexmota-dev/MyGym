using MyGym.Models;
using MyGym.Repository.Interface;

namespace MyGym.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<UserModel> Create(UserModel model)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> Update(UserModel model, string id)
        {
            throw new NotImplementedException();
        }
    }
}
