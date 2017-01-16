using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Hone.Entidades
{
    public class CondPagto
    {
        [NotNull]
        public int GroupNum { get; set; }
        [NotNull]
        public string PymntGroup { get; set; }
    }
}
