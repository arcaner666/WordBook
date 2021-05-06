using System;
using System.Collections.Generic;

#nullable disable

namespace WordBook.DatabaseModels
{
    public partial class Box
    {
        public Box()
        {
            Words = new HashSet<Word>();
        }

        public int BoxId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Word> Words { get; set; }
    }
}
