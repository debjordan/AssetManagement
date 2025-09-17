using AssetManagement.Domain.Entities;

namespace AssetManagement.Domain.Services
{
    public interface IAuthDomainService
    {
        Task<User> ValidateUserAsync(string username, string password);
        string GenerateJwtToken(User user);
    }
}
