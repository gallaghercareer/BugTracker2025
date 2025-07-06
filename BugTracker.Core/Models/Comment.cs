using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Ticket")]
        public int TicketId { get; set; }

        public Ticket? Ticket { get; set; }

        // Azure Entra ID object ID (e.g., 9e1b5c89-5b0c-423b-a5b6-8a29f82d4140)
        [Required]
        [MaxLength(36)]
        public string CreatedByUserId { get; set; } = string.Empty;

        public string CreatedByDisplayName { get; set; } = string.Empty;


        [Required]
        public string Text { get; set; } = string.Empty;


    }
}
