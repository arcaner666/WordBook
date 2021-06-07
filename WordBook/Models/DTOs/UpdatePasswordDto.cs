using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordBook.Models.DTOs
{
    public class UpdatePasswordDto
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
