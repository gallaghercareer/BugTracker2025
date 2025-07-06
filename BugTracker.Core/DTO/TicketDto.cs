using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.DTO
{
    public class TicketDto
    {
        public int Id { get; set; }  
        public string UserId { get; set; } = "";
        public DateTime Date { get; set; }
        public bool Resolved { get; set; }
        public string Instructions { get; set; } = "";
    }
}
