using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.ViewModel.User
{
    public class EditUserProfileViewModel
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
    }
}
