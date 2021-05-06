using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordBook.Models.DTOs
{
    public class WordDto
    {
        public int WordId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public int BoxId { get; set; }
        public string Word1 { get; set; }
        public string Meaning1 { get; set; }
        public string Meaning2 { get; set; }
        public string Meaning3 { get; set; }
    }
}
