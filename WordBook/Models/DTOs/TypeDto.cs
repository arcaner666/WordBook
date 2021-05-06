using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordBook.Models.DTOs
{
    public class TypeDto
    {
        public int TypeId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
