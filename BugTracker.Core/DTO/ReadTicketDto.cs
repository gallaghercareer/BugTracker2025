using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.DTO
{
    public class ReadTicketDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = "";
        public DateTime Date { get; set; }
        public bool Resolved { get; set; }
        public string Instructions { get; set; } = "";
    }

}
