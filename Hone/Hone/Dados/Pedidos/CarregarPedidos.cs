using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Dados.Services;
using Hone.Entidades;
using Xamarin.Forms;

namespace Hone.Dados.Pedidos
{
    public class CarregarPedidos : ICarregarPedidos
    {
        ICrudFormaPgto crudFP = null;
        ICondPgtos crudCP = null;
        ICrudItens crudItem = null;
        ICrudPedidos crudPed = null;

        public CarregarPedidos()
        {
            crudFP = DependencyService.Get<ICrudFormaPgto>();
            crudCP = DependencyService.Get<ICondPgtos>();
            crudItem = DependencyService.Get<ICrudItens>();
            crudPed = DependencyService.Get<ICrudPedidos>();
        }

        public Pedido CarregarPedido(int idPedido)
        {
            Pedido pedido = null;
            using (AcessarDados _Dados = new AcessarDados())
            {
                SetDados(_Dados);
                //Dados.Entidades.Pedidos dadosPedido = crudPed.ListarPedido(idPedido);
                //ObservableCollection<Dados.Entidades.Itens> dadosItens = crudItem.ListarItens(idPedido);
                //Dados.Entidades.CondPagtos dadosCondPgto = crudCP.ListarCondPgto(dadosPedido.CondPagto);
                //Dados.ent
            }
        }

        private void SetDados(AcessarDados _Dados)
        {
            crudCP.SetDados(_Dados);
            crudFP.SetDados(_Dados);
            crudItem.SetDados(_Dados);
            crudPed.SetDados(_Dados);
        }

        public ObservableCollection<Pedido> CarregarPedidoPorCliente(string cardCode)
        {
            throw new NotImplementedException();
        }

        ObservableCollection<Pedido> ICarregarPedidos.CarregarPedidos()
        {
            throw new NotImplementedException();
        }
    }
}
