using BugTracker.Core.Interfaces;
using BugTracker.Core.Models;
using BugTracker.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly BugTrackerContext _context;

        public TicketRepository(BugTrackerContext context)
        {
            _context = context;
        }

        public Task CreateTicketAsync(Ticket ticket)
        {
            //add filter


            //saveChanges
            throw new NotImplementedException();

        }

        public void DeleteTicketAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ticket?> GetTicketByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTicketAsync(Ticket id)
        {
            throw new NotImplementedException();
        }
    }
}
