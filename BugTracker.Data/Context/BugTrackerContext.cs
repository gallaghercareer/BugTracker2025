using BugTracker.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data.Context
{

    public class BugTrackerContext : DbContext
    {
        public BugTrackerContext(DbContextOptions<BugTrackerContext> options)
            : base(options) { }

        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
    }
}