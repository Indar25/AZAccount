using Account.Application.Command;
using Account.Application.Profiles;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateUserCommand>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly));

        services.AddAutoMapper(typeof(CreateUserCommandProfile).Assembly);

        return services;
    }
}

