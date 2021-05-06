using System;
using System.Collections.Generic;

#nullable disable

namespace WordBook.DatabaseModels
{
    public partial class AchievementType
    {
        public AchievementType()
        {
            Achievements = new HashSet<Achievement>();
        }

        public int AchievementTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }
    }
}
