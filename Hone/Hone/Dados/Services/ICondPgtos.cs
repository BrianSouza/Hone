using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hone.Dados.Services
{
    interface ICondPgtos
    {
        void SetDados(AcessarDados dados);

        int InsertCondPgto(Entidades.CondPagtos condPgtos);

        int UpdateCondPgto(Entidades.CondPagtos condPgtos);

        int DeleteCondPgto(Entidades.CondPagtos condPgtos);

        ObservableCollection<Entidades.CondPagtos> ListarCondPgto();

        Entidades.CondPagtos ListarCondPgto(string paymethcod);
    }
}
