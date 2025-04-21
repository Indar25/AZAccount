using Account.Application.DTOs;
using Account.Persistence.Identity;
using AutoMapper;

namespace Account.Application.Profiles;
public class ApplicationUserProfile : Profile
{
    public ApplicationUserProfile()
    {
        CreateMap<ApplicationUser, UserDto>();
    }
}