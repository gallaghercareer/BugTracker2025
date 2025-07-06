using BugTracker.Core.Interfaces;
using BugTracker.Data.Context;
using BugTracker.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data
{
   public static class DIExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
        {
            // Register EF Core context
            services.AddDbContext<BugTrackerContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            // Register repositories
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            return services;
        }
    }
}
