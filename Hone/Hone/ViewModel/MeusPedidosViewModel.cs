using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hone.Entidades;

namespace Hone.ViewModel
{
    public class MeusPedidosViewModel : BaseViewModel
    {
        public MeusPedidosViewModel()
        {
            CarregarPedidos();
        }
        public struct StatusPed
        {
            public int StatusId { get; set; }
            public string StatusName { get; set; }
        }
        //private int selectedStatusIndex;
        private List<Pedido> lstPedidos;
        //private DateTime dataDe;
        //private DateTime dataAte;
        //private StatusPed selectedStatus;
        private IEnumerable<Group<char, Pedido>> listaFiltro;
        private string textoFiltro;

        //public DateTime DataAte
        //{
        //    get
        //    {
        //        return dataAte;
        //    }

        //    set
        //    {
        //        dataAte = value;
        //        this.Notify("DataAte");
        //    }
        //}

        //public DateTime DataDe
        //{
        //    get
        //    {
        //        return dataDe;
        //    }

        //    set
        //    {
        //        dataDe = value;
        //        this.Notify("dataDe");
        //    }
        //}

        public List<Pedido> LstPedidos
        {
            get
            {
                return lstPedidos;
            }

            set
            {
                lstPedidos = value;
            }
        }

        public IEnumerable<Group<char, Pedido>> ListaFiltro
        {
            get
            {
                return listaFiltro;
            }

            set
            {
                listaFiltro = value;
                this.Notify("ListaFiltro");
            }
        }

        public string TextoFiltro
        {
            get
            {
                return textoFiltro;
            }

            set
            {
                textoFiltro = value;
                FiltrarPedidoNomePN();
                this.Notify("TextoFiltro");
            }
        }

        private void CarregarPedidos()
        {
            LstPedidos = new List<Pedido>
            {
                new Pedido {CondPagto = new CondPagto {GroupNum = 1 , PymntGroup = "A vista" },
                    DtEntrega = DateTime.Now,
                    FormaPgto = new FormaPgto {PayMethCod = "01",Descript = "Dinheiro" },
                    Id = 1 ,
                Itens = new ObservableCollection<Item> { new Item { ItemCode = "001",ItemName = "ITEM 01",Quantidade = 10 ,ValorUnit =100} } ,
                Parceiro = new Parceiro {CardCode = "C001",CardName = "Cliente Teste" }
                },

                new Pedido {CondPagto = new CondPagto {GroupNum = 1 , PymntGroup = "A vista" },
                    DtEntrega = DateTime.Now.Date.AddDays(-1),
                    FormaPgto = new FormaPgto {PayMethCod = "01",Descript = "Dinheiro" },
                    Id = 2 ,
                Itens = new ObservableCollection<Item> { new Item { ItemCode = "001",ItemName = "ITEM 01",Quantidade = 10 ,ValorUnit =100} } ,
                Parceiro = new Parceiro {CardCode = "C0012",CardName = "Cliente Teste 12" } }

            };

            FiltrarPedido();
        }

        private void FiltrarPedido()
        {
            IEnumerable<Pedido> ListaFltrada = FiltrarPedidoNomePN();
            AgruparResultados(ListaFltrada);
        }
        private void AgruparResultados(IEnumerable<Pedido> ListaFltrada)
        {
            ListaFiltro = (from ped in ListaFltrada
                           orderby ped.Parceiro.CardName
                           group ped by ped.Parceiro.CardName[0] into grupos
                           select new Group<char, Pedido>(grupos.Key, grupos));
        }
        private IEnumerable<Pedido> FiltrarPedidoNomePN()
        {
            IEnumerable<Pedido> ListaFltrada = LstPedidos;
            if (!string.IsNullOrEmpty(TextoFiltro))
                ListaFltrada = LstPedidos.Where(P => P.Parceiro.CardName.ToLower().Contains(TextoFiltro.ToLower()));
            return ListaFltrada;
        }

        //public StatusPed SelectedStatus
        //{
        //    get
        //    {
        //        return selectedStatus;
        //    }

        //    set
        //    {
        //        selectedStatus = value;
        //        Notify("SelectedStatus");
        //    }
        //}
        //public int SelectedStatusIndex
        //{
        //    get { return selectedStatusIndex; }
        //    set
        //    {
        //        selectedStatusIndex = value;
        //        SelectedStatus = ListaStatusPedido[value];
        //        this.Notify("SelectedStatusIndex");
        //    }
        //}
        //public ObservableCollection<StatusPed> ListaStatusPedido = new ObservableCollection<StatusPed>
        //{
        //    new StatusPed {StatusId = 0 , StatusName = "Todos" },
        //    new StatusPed {StatusId = 1 , StatusName = "Sincronizado" },
        //    new StatusPed {StatusId = 2 , StatusName = "Ñ Sincronizado" }

        //};
    }
}
