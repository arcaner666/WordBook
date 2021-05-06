using System;
using System.Collections.Generic;

#nullable disable

namespace WordBook.DatabaseModels
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public string CreatedAt { get; set; }

        public virtual User Friend { get; set; }
        public virtual User User { get; set; }
    }
}
