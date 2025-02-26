using CQRS_Test_Project.Core.Application.Features.Commands.User.CreateUser;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Validations.User;
using CQRS_Test_Project.Infrastructure.Persistence.Repository;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS_Test_Project.Infrastructure.Persistence;

public static class ServiceRegistrations
{
    public static IServiceCollection AddPersistanceLayerServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IActivityLogRepository, ActivityLogRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
           
        return services;

        
    }
}