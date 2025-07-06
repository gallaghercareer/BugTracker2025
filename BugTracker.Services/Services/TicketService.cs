using BugTracker.Core.DTO;
using BugTracker.Core.Interfaces;
using BugTracker.Core.Models;
using BugTracker.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Services.Services
{
    public class TicketService : ITicketService

    {
        private readonly BugTrackerContext _db;

        public TicketService(BugTrackerContext db) => _db = db;

        //CREATE
    
        public async Task<TicketDto> CreateAsync(CreateTicketDto dto, string userId)
        {
            var entity = new Ticket
            {
                UserId = userId,
                Date = dto.Date,
                Resolved = dto.Resolved,
                Instructions = dto.Instructions
            };

            _db.Tickets.Add(entity);
            await _db.SaveChangesAsync();

            return new TicketDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Date = entity.Date,
                Resolved = entity.Resolved,
                Instructions = entity.Instructions
            };
        }



        //READ
        public async Task<IEnumerable<ReadTicketDto>> GetAllAsync()
        {
            return await _db.Tickets
                .Select(t => new ReadTicketDto
                {
                    Id = t.Id,
                    UserId = t.UserId,
                    Date = t.Date,
                    Resolved = t.Resolved,
                    Instructions = t.Instructions
                })
                .ToListAsync();
        }
        public async Task<ReadTicketDto?> GetByIdAsync(int id)
        {
            return await _db.Tickets
                .Where(t => t.Id == id)
                .Select(t => new ReadTicketDto
                {
                    Id = t.Id,
                    UserId = t.UserId,
                    Date = t.Date,
                    Resolved = t.Resolved,
                    Instructions = t.Instructions
                })
                .FirstOrDefaultAsync();
        }
    
        
    
    }
}
