using System;
using System.Collections.Generic;

#nullable disable

namespace WordBook.DatabaseModels
{
    public partial class SharedWord
    {
        public int SharedWordId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int WordId { get; set; }
        public string CreatedAt { get; set; }

        public virtual User Receiver { get; set; }
        public virtual User Sender { get; set; }
        public virtual Word Word { get; set; }
    }
}
