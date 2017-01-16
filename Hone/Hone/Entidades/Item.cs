﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Hone.Entidades
{
    public class Item
    {
        [NotNull]
        public string ItemName { get; set; }
        [NotNull]
        public string ItemCode { get; set; }
        [NotNull]
        public double Quantidade { get; set; }
        [NotNull]
        public double ValorUnit { get; set; }
    }
}
