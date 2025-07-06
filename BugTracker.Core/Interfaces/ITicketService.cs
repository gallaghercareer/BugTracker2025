using BugTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace BugTracker.Core.Interfaces
{
    public interface ITicketService
    {
        //CREATE
        Task<TicketDto> CreateAsync(CreateTicketDto dto, string userId);

        //READ
        Task<IEnumerable<ReadTicketDto>> GetAllAsync();
         Task<ReadTicketDto?> GetByIdAsync(int id);
    }
}
