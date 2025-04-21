using Account.Application.Command;
using Account.Persistence.Identity;
using AutoMapper;

namespace Account.Application.Profiles;
public class CreateUserCommandProfile : Profile
{
    public CreateUserCommandProfile()
    {
        CreateMap<CreateUserCommand, ApplicationUser>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
    }
}

