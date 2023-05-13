using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Enum
{
    public static class UserLevel
    {
        public const string Admin = "admin";
        public const string Moderator = "moderator";
        public const string User = "user";
    }
}
