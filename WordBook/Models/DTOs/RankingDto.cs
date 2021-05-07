using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordBook.Models.DTOs
{
    public class RankingDto
    {
        public int RankId { get; set; }
        public int UserId { get; set; }
        public int RankTypeId { get; set; }
        public int Score { get; set; }
        public string UpdatedAt { get; set; }
    }
}
