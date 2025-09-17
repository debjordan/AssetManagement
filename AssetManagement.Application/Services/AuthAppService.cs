using AssetManagement.Application.DTOs;
using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Services;
using AutoMapper;

namespace AssetManagement.Application.Services
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IAuthDomainService _authDomainService;
        private readonly IMapper _mapper;

        public AuthAppService(IAuthDomainService authDomainService, IMapper mapper)
        {
            _authDomainService = authDomainService;
            _mapper = mapper;
        }

        public async Task<AuthResponse> AuthenticateAsync(AuthRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                throw new ArgumentException("Username and password are required");

            var user = await _authDomainService.ValidateUserAsync(request.Username, request.Password);

            if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials");

            var token = _authDomainService.GenerateJwtToken(user);
            var userResponse = _mapper.Map<UserResponse>(user);

            return new AuthResponse
            {
                Token = token,
                User = userResponse,
                ExpiresAt = DateTime.UtcNow.AddHours(2)
            };
        }

        public async Task<UserResponse> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
