using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordBook.Models.DTOs
{
    public class ContactDto
    {
        public int ContactId { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public string CreatedAt { get; set; }
    }
}
