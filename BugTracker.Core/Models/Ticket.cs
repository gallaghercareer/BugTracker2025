using BugTracker.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        
        [Required]
        public string UserId { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public bool Resolved { get; set; }

        [Required]
        public string Instructions { get; set; } = string.Empty;

      

    }
}
