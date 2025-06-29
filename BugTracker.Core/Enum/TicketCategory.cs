using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Core.Enum
{
    public enum TicketCategory
    {
      
        Hardware,
        [Display(Name = "Internet Connectivity")]
        Network,
        [Display(Name ="Login Access")]
        PasswordReset,
        Bug,
        Other

    }
}
