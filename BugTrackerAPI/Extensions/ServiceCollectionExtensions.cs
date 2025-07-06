using BugTracker.Core.Interfaces;
using BugTracker.Data.Context;
using BugTracker.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBugTrackerServices(
           this IServiceCollection services,
           IConfiguration config)
        {
         

            // register your application services

            return services;
        }
    }
}
