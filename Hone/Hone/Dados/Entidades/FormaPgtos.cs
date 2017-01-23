using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Hone.Dados.Entidades
{
    public class FormaPgtos
    {
        [NotNull]
        public string PayMethCod { get; set; }
        [NotNull]
        public string Descript { get; set; }
        [NotNull]
        public string Type { get; set; }
    }
}
