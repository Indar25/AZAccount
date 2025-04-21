using Account.Application.DTOs;
using Account.Persistence.Identity;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Account.Application.Query;
public record GetUserQuery : IRequest<List<UserDto>>;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<UserDto>>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    public GetUserQueryHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<List<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {

        var users = await _userManager.Users.ToListAsync(cancellationToken);
        return _mapper.Map<List<UserDto>>(users);
    }
}

