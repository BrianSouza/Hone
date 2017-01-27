using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hone.Dados.Services
{
    interface ICrudPedidos
    {
        void SetDados(AcessarDados dados);

        int InsertPedido(Entidades.Pedidos pedido);

        int UpdatePedido(Entidades.Pedidos pedido);

        int DeletePedido(Entidades.Pedidos pedido);

        ObservableCollection<Entidades.Pedidos> ListarPedidos();

        ObservableCollection<Entidades.Pedidos> ListarPedidos(string cardCode);

        Entidades.Pedidos ListarPedido(int idPedido);

    }
}
