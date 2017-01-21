using System;
using System.Collections.ObjectModel;


namespace Hone.Entidades
{
    public class Pedido
    {

        public int Id { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime DtEntrega { get; set; }
        public Parceiro Parceiro { get; set; }

        public FormaPgto FormaPgto { get; set; }

        public CondPagto CondPagto { get; set; }
        public ObservableCollection<Item> Itens { get; set; }


    }
}
