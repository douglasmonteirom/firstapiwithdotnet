using ManagementSystem.Data;
using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Repositories.Interfaces
{
    public class UserRepositorie : IUsersRepositorie
    {
        private readonly AppDbContext _dbContext;
        public UserRepositorie(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel?> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(userDb => userDb.Id == id);
        }

        public async Task<UserModel> AddUser(UserModel userModel)
        {
            await _dbContext.Users.AddAsync(userModel);
            await _dbContext.SaveChangesAsync();

            return userModel;
        }

        public async Task<bool> RemoveUser(UserModel user)
        {
            // TODO: remover somente com id
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<UserModel> UpdateUser(UserModel user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            
            return user;
        }
    }
}