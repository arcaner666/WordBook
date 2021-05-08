﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordBook.Models.DTOs
{
    public class SharedWordDto
    {
        public int SharedWordId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int WordId { get; set; }
        public string CreatedAt { get; set; }
    }
}
