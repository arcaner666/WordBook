using System;
using System.Collections.Generic;

#nullable disable

namespace WordBook.DatabaseModels
{
    public partial class ContactRequest
    {
        public int ContactRequestId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string CreatedAt { get; set; }

        public virtual User Receiver { get; set; }
        public virtual User Sender { get; set; }
    }
}
