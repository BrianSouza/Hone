using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Dados.Entidades;
using Hone.Dados.Services;

namespace Hone.Dados.Pedidos
{
    public class CrudPedidos : ICrudPedidos
    {
        AcessarDados _Dados;
        public CrudPedidos()
        {
        }

        public int DeletePedido(Entidades.Pedidos pedido)
        {
            int id = 0;
            id = _Dados.Delete<Entidades.Pedidos>(pedido);
            return id;
        }

        public int InsertPedido(Entidades.Pedidos pedido)
        {
            int id = 0;
            id = _Dados.Insert<Entidades.Pedidos>(pedido);
            return id;
        }

        public ObservableCollection<Entidades.Pedidos> ListarPedido(string cardCode)
        {
            throw new NotImplementedException();

        }

        public ObservableCollection<Entidades.Pedidos> ListarPedidos()
        {
            ObservableCollection<Entidades.Pedidos> pns = new ObservableCollection<Entidades.Pedidos>();

            pns = new ObservableCollection<Entidades.Pedidos>(_Dados._conexao.Table<Entidades.Pedidos>());
            return pns;
        }

        public void SetDados(AcessarDados dados)
        {
            _Dados = dados;
        }

    public int UpdatePedido(Entidades.Pedidos pedido)
        {
            int id = 0;
            id = _Dados.Update<Entidades.Pedidos>(pedido);
            return id;
        }
    }
}
