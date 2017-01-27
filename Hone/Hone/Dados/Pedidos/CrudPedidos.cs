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
        public CrudPedidos()
        {
        }
        AcessarDados _Dados = null;
        public void SetDados(AcessarDados dados)
        {
            _Dados = dados;
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
        

        public ObservableCollection<Entidades.Pedidos> ListarPedidos()
        {
            var pedidos = new ObservableCollection<Entidades.Pedidos>(_Dados._conexao.Table<Entidades.Pedidos>());
            return pedidos;
        }

        public int UpdatePedido(Entidades.Pedidos pedido)
        {
            int id = 0;
            id = _Dados.Update<Entidades.Pedidos>(pedido);
            return id;
        }

        public ObservableCollection<Entidades.Pedidos> ListarPedidos(string cardCode)
        {
            var pedidos = new ObservableCollection<Entidades.Pedidos>(_Dados._conexao.Table<Entidades.Pedidos>());

            return new ObservableCollection<Entidades.Pedidos>(pedidos.Where(T0 => T0.CardCode.Equals(cardCode)).ToList());
        }

        public Entidades.Pedidos ListarPedido(int idPedido)
        {
            var pedidos = new ObservableCollection<Entidades.Pedidos>(_Dados._conexao.Table<Entidades.Pedidos>());
            return pedidos.Where(T0 => T0.Id.Equals(idPedido)).FirstOrDefault();
        }
    }
}
