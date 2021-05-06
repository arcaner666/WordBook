using System;
using System.Collections.Generic;

#nullable disable

namespace WordBook.DatabaseModels
{
    public partial class Word
    {
        public Word()
        {
            SharedWords = new HashSet<SharedWord>();
        }

        public int WordId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public int BoxId { get; set; }
        public string Word1 { get; set; }
        public string Meaning1 { get; set; }
        public string Meaning2 { get; set; }
        public string Meaning3 { get; set; }

        public virtual Box Box { get; set; }
        public virtual Category Category { get; set; }
        public virtual Type Type { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<SharedWord> SharedWords { get; set; }
    }
}
