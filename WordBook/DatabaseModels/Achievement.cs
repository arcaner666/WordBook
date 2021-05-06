using System;
using System.Collections.Generic;

#nullable disable

namespace WordBook.DatabaseModels
{
    public partial class Achievement
    {
        public int AchievementId { get; set; }
        public int UserId { get; set; }
        public int AchievementTypeId { get; set; }
        public int Score { get; set; }
        public string UpdatedAt { get; set; }

        public virtual AchievementType AchievementType { get; set; }
        public virtual User User { get; set; }
    }
}
