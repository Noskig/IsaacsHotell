﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsaacsHotell.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Double Pris { get; set; }

        public int GästId { get; set; }
        public Gäst Gäst { get; set; }
    }
}