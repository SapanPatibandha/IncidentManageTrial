using IncidentManagement.Application.Interfaces;
using IncidentManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using IncidentManagement.Domain.Interfaces;
using IncidentManagement.Infrastructure.Repositories;

namespace IncidentManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IIncidentRepository, IncidentRepository>();
            services.AddScoped<IIncidentService, IncidentService>();

            return services;
        }
    }
}