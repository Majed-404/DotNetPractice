﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; } //PK
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public List<ProductAttachment> Attachments { get; set; }
    }
}
