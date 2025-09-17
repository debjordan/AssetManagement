using AssetManagement.Application.DTOs;
using AssetManagement.Domain.Entities;
using AutoMapper;

namespace AssetManagement.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>();
        }
    }
}
