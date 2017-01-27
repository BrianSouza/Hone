
using System.Collections.ObjectModel;
using Hone.Entidades;

namespace Hone.Dados.Services
{
    interface ICarregarPedidos
    {
        ObservableCollection<Pedido> CarregarPedidos();

        Pedido CarregarPedido(int idPedido);

        ObservableCollection<Pedido> CarregarPedidoPorCliente(string cardCode);
    }
}
