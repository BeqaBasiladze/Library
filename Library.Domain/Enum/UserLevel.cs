using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Enum
{
    public enum UserLevel
    {
        [Display(Name = "User")]
        User = 0,
        [Display(Name = "Manager")]
        Manager = 1,
        [Display(Name = "Admin")]
        Admin = 2
    }
}
