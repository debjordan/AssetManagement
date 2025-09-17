using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.DTOs
{
    public class AuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthResponse
    {
        public string Token { get; set; }
        public UserResponse User { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
