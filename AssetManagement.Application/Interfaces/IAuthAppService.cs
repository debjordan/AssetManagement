using AssetManagement.Application.DTOs;

namespace AssetManagement.Application.Interfaces
{
    public interface IAuthAppService
    {
        Task<AuthResponse> AuthenticateAsync(AuthRequest request);
        Task<UserResponse> GetUserByIdAsync(Guid id);
    }
}
