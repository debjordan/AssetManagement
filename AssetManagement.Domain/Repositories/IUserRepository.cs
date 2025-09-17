using AssetManagement.Domain.Entities;

namespace AssetManagement.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
        Task<bool> UsernameExistsAsync(string username);
    }
}
