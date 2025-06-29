using BugTracker.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public TicketCategory Category { get; set; }
        public string Description { get; set; } = string.Empty;
        public TicketStatus Status { get; set; }

        //TicketCreator

        //TicketTechnicain

    }
}
