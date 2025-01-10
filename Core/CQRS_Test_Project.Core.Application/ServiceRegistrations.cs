using CQRS_Test_Project.Core.Application.Features.Commands.User.CreateUser;
using CQRS_Test_Project.Core.Application.Validations.User;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS_Test_Project.Core.Application
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddAplicationLayerServices(this IServiceCollection services)
        {
            var currentAssembly = typeof(ServiceRegistrations).Assembly;

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(currentAssembly);
            });

            services.AddAutoMapper(currentAssembly);

            services.AddScoped<IValidator<CreateUserCommandRequest>, CreateUserCommandRequestValidator>();

            
           
            return services;



        }

    }
}
