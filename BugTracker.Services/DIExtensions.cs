using BugTracker.Core.Interfaces;
using BugTracker.Services.Services;
using Microsoft.Extensions.DependencyInjection;


namespace BugTracker.Services
{
    //wires dependency injection into the API program.cs
    public static class DIExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ITicketService, TicketService>();
            
            return services;
        }
    }
}
