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
   public class BugTrackerContext(DbContextOptions<BugTrackerContext> options) : DbContext(options)
    {
        DbSet<Ticket> Tickets { get; set; }

    }
}
