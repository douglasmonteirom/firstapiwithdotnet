using ManagementSystem.Models;

namespace ManagementSystem.Repositories.Interfaces
{
    public interface IUsersRepositorie
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel?> GetUserById(int id);
        Task<UserModel> AddUser(UserModel userModel);
        Task<UserModel> UpdateUser(UserModel user);
        Task<bool> RemoveUser(UserModel user);
    }
}