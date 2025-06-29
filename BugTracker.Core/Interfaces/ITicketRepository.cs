using BugTracker.Core.Models;


namespace BugTracker.Core.Interfaces
{
    public interface ITicketRepository
    {

        //Get Ticket
        Task<Ticket?> GetTicketByIdAsync(int id);

        //Get All Tickets
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();

        //Create Ticket
        Task CreateTicketAsync(Ticket ticket);

        //Update Ticket
        void UpdateTicketAsync(Ticket id);

        //Delete Ticket
        void DeleteTicketAsync(int id);
    }
}
