using Account.Application.DTOs;
using Account.Persistence.Identity;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Account.Application.Query;
public record GetUserByIdQuery(string email) : IRequest<UserDto>;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.email);
        return _mapper.Map<UserDto>(user);
    }
}

