using System;
using System.Collections.Generic;

#nullable disable

namespace WordBook.DatabaseModels
{
    public partial class Ranking
    {
        public int RankId { get; set; }
        public int UserId { get; set; }
        public int RankTypeId { get; set; }
        public int Score { get; set; }
        public string UpdatedAt { get; set; }

        public virtual RankType RankType { get; set; }
        public virtual User User { get; set; }
    }
}
