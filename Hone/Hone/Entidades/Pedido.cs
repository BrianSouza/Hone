using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Hone.Entidades
{
    public class Pedido
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public DateTime DtCadastro { get; set; }
        public DateTime DtEntrega { get; set; }
        [NotNull]
        public Parceiro Parceiro { get; set; }
        [NotNull]
        public FormaPgto FormaPgto { get; set; }
        [NotNull]
        public CondPagto CondPagto { get; set; }
        [NotNull]
        public ObservableCollection<Item> Itens { get; set; }
    }
}
