﻿using GameProjectDemo.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectDemo.Entities
{
    public class Campaign : IEntity
    {
        public int Id { get; set; }
        public double DiscountRate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
