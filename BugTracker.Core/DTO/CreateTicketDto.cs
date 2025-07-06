using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.DTO
{
    public class CreateTicketDto
    {
        public DateTime Date { get; set; }
        public bool Resolved { get; set; }
        public string Instructions { get; set; } = "";
    }

}
