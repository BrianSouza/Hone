using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Dados.Entidades;
using Hone.Dados.Services;

namespace Hone.Dados.Parceiros
{
    public class CrudParceiros : ICrudParceiros
    {
        AcessarDados _Dados = null;
        public int DeleteParceiro(Entidades.Parceiros pn)
        {
            int deleted = 0;
            deleted = _Dados.Delete<Entidades.Parceiros>(pn);
            return deleted;
        }

        public int InsertParceiro(Entidades.Parceiros pn)
        {
            int inserted = 0;
            inserted = _Dados.Delete<Entidades.Parceiros>(pn);
            return inserted;
        }

        public Entidades.Parceiros ListarParceiro(string cardCode)
        {
            Entidades.Parceiros pn = new Entidades.Parceiros();
            var listaPn = _Dados._conexao.Table<Entidades.Parceiros>();
            pn = listaPn.Where(T0 => T0.CardCode.Equals(cardCode)).FirstOrDefault();
            return pn;
        }

        public ObservableCollection<Entidades.Parceiros> ListarParceiros()
        {
            ObservableCollection<Entidades.Parceiros> pns = new ObservableCollection<Entidades.Parceiros>(_Dados._conexao.Table<Entidades.Parceiros>());
            return pns;
        }

        public void SetDados(AcessarDados dados)
        {
            _Dados = dados;
        }

        public int UpdateParceiro(Entidades.Parceiros pn)
        {
            int updated = 0;
            updated = _Dados.Delete<Entidades.Parceiros>(pn);
            return updated;
        }
    }
}
