using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hone.Dados.Services
{
    interface ICrudFormaPgto
    {
        void SetDados(AcessarDados dados);

        int InsertFormPgto(Entidades.FormaPgtos formaPgtos);

        int UpdateFormPgto(Entidades.FormaPgtos formaPgtos);

        int DeleteFormPgto(Entidades.FormaPgtos formaPgtos);

        ObservableCollection<Entidades.FormaPgtos> ListarFormasPgto();

        Entidades.FormaPgtos ListarFormaPgto(string groupCode);
    }
}
