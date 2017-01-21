using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Hone.Dados.Entidades
{
    public class Pedidos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public DateTime DtCadastro { get; set; }
        
        public DateTime DtEntrega { get; set; }
        [NotNull]
        public string CardCode { get; set; }
        [NotNull]
        public string CardName { get; set; }
        [NotNull]
        public string FormaPgto { get; set; }

        public string CondPagto { get; set; }
    }
}
