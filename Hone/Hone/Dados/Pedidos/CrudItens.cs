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
    public class CrudItens : ICrudItens
    {
        public int DeleteItens(Itens itens)
        {
            int id = 0;
            using (AcessarDados _Dados = new AcessarDados())
            {
                id = _Dados.Delete<Entidades.Itens>(itens);
            }
            return id;
        }

        public int InsertItens(Itens itens)
        {
            int id = 0;
            using (AcessarDados _Dados = new AcessarDados())
            {
                id = _Dados.Insert<Entidades.Itens>(itens);
            }
            return id;
        }

        public ObservableCollection<Itens> ListarItens()
        {
            ObservableCollection<Entidades.Itens> pns = new ObservableCollection<Entidades.Itens>();
            using (AcessarDados _Dados = new AcessarDados())
            {
                pns = new ObservableCollection<Entidades.Itens>(_Dados._conexao.Table<Entidades.Itens>());
            }
            return pns;
        }

        public ObservableCollection<Itens> ListarItens(string pedido)
        {
            throw new NotImplementedException();
        }

        public int UpdateItens(Itens itens)
        {
            int id = 0;
            using (AcessarDados _Dados = new AcessarDados())
            {
                id = _Dados.Update<Entidades.Itens>(itens);
            }
            return id;
        }
    }
}
