using BugTracker.Core.Models;

namespace BugTracker.ViewModels
{
    public class MultipleTicketsModel
    {
        public List<Ticket>? Tickets { get; set; }

        public Ticket? Ticket { get; set; }

        public List<Comment>? Comments { get; set; }

        public Comment? Comment { get; set; }
    }
}
