using System;
using System.Collections.Generic;

#nullable disable

namespace WordBook.DatabaseModels
{
    public partial class RankType
    {
        public RankType()
        {
            Rankings = new HashSet<Ranking>();
        }

        public int RankTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ranking> Rankings { get; set; }
    }
}
