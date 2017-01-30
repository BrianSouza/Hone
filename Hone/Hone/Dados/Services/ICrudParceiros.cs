using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hone.Dados.Services
{
    interface ICrudParceiros
    {
        void SetDados(AcessarDados dados);

        int InsertParceiro(Entidades.Parceiros pn);

        int UpdateParceiro(Entidades.Parceiros pn);

        int DeleteParceiro(Entidades.Parceiros pn);

        ObservableCollection<Entidades.Parceiros> ListarParceiros();

        Entidades.Parceiros ListarParceiro(string cardCode);
    }
}
