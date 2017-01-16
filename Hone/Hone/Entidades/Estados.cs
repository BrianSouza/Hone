using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hone.Entidades
{
    public class Estados
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }

        public Estados(string nome, string sigla)
        {
            Nome = nome;
            Sigla = sigla;
        }
    }
}
