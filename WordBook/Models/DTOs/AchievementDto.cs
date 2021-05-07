using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordBook.Models.DTOs
{
    public class AchievementDto
    {
        public int AchievementId { get; set; }
        public int UserId { get; set; }
        public int AchievementTypeId { get; set; }
        public int Score { get; set; }
        public string UpdatedAt { get; set; }
    }
}
