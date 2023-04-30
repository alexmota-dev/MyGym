using Microsoft.EntityFrameworkCore;
using MyGym.Data;
using MyGym.Models;
using MyGym.Repository.Interface;

namespace MyGym.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyGymDBContext _dbContext;
        public UserRepository(MyGymDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserModel> Create(UserModel model)
        {
            await _dbContext.Users.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<bool> Delete(string id)
        {
            UserModel userDeleting = await _dbContext.Users.FirstAsync(x => x.Id == id);
            _dbContext.Users.Remove(userDeleting);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<List<UserModel>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetById(string id)
        {
            return await _dbContext.Users.FirstAsync(x => x.Id == id);
        }

        public async Task<UserModel> Update(UserModel model, string id)
        {
            UserModel existingUser = await GetById(id) ?? throw new Exception($"Não existe user com ${id}");

            existingUser.Name = model.Name;
            existingUser.Password = model.Password;
            existingUser.Email = model.Email;
            existingUser.Avatar = model.Avatar;

            _dbContext.Users.Update(existingUser);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<UserModel> GetByEmailAndPassword(string email, string password)
        {
            UserModel existingUser = await _dbContext.Users.FirstAsync(x => x.Email == email && x.Password == password);
            return existingUser;
        }
    }
}
