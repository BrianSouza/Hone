using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hone.Entidades;
using Newtonsoft.Json;
using Hone.View;


namespace Hone.ViewModel
{
    public class MeusPedidosViewModel : BaseViewModel
    {
        public MeusPedidosViewModel()
        {
            LoadPedidos();

        }
        public struct StatusPed
        {
            public int StatusId { get; set; }
            public string StatusName { get; set; }
        }
        private List<Pedido> lstPedidos;
        private IEnumerable<Group<char, Pedido>> listaFiltro;
        private string textoFiltro;
        private Pedido selectedPedido;

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
                FiltrarPedido();
                this.Notify("TextoFiltro");
            }
        }

        public Pedido SelectedPedido
        {
            get
            {
                return selectedPedido;
            }

            set
            {
                selectedPedido = value;
                this.Notify("SelectedPedido");
                SalvarTxtPedidoENavegar();
            }
        }

        private void LoadPedidos()
        {
            
            //LstPedidos =

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

        public void SalvarTxtPedidoENavegar()
        {
            if (selectedPedido != null)
            {
                string ped = JsonConvert.SerializeObject(SelectedPedido);
                _SaveAndLoad.SaveText("Pedido.txt", ped);
                NavegarParaPedido();
            }
        }

        private async void NavegarParaPedido()
        {
            if (_SaveAndLoad.ValidateExist("Pedido.txt"))
                await _Navigation.NavigateTo(new PedView());
        }
    }
}
