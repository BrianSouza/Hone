using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hone.Dados.Services
{
    interface ICrudItens
    {
        void SetDados(AcessarDados dados);

        int InsertItens(Entidades.Itens itens);

        int UpdateItens(Entidades.Itens itens);

        int DeleteItens(Entidades.Itens itens);

        ObservableCollection<Entidades.Itens> ListarItens();

        ObservableCollection<Entidades.Itens> ListarItens(int pedido);

    }
}
