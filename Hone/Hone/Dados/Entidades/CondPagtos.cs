using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Hone.Dados.Entidades
{
    public class CondPagtos
    {
        [NotNull]
        public int GroupNum { get; set; }
        [NotNull]
        public string PymntGroup { get; set; }
    }
}
