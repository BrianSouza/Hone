
using System.Collections.ObjectModel;
using Hone.Entidades;

namespace Hone.Dados.Services
{
    interface ICarregarPedidos
    {
        ObservableCollection<Pedido> CarregarPedidos();

        Pedido CarregarPedidos(int idPedido);

        ObservableCollection<Pedido> CarregarPedidos(string cardCode);
    }
}
