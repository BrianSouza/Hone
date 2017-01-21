using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Hone.Entidades
{
    public class Item
    {
        
        public string ItemName { get; set; }
        
        public string ItemCode { get; set; }
        
        public double Quantidade { get; set; }
        
        public double ValorUnit { get; set; }
    }
}
