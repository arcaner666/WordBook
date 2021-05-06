using System;
using System.Collections.Generic;

#nullable disable

namespace WordBook.DatabaseModels
{
    public partial class Type
    {
        public Type()
        {
            Words = new HashSet<Word>();
        }

        public int TypeId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Word> Words { get; set; }
    }
}
