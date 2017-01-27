using System;
using System.Collections.ObjectModel;
using System.Linq;
using Hone.Dados.Services;

namespace Hone.Dados.CondPgto
{
    public class CrudCondPgtos : ICondPgtos
    {
        Hone.Dados.AcessarDados _Dados = null;

        public int DeleteCondPgto(Dados.Entidades.CondPagtos condPgtos)
        {
            int deleted = 0;
            deleted = _Dados.Delete<Dados.Entidades.CondPagtos>(condPgtos);
            return deleted;
        }

        public int InsertCondPgto(Dados.Entidades.CondPagtos condPgtos)
        {
            int inserted = 0;
            inserted = _Dados.Insert<Dados.Entidades.CondPagtos>(condPgtos);
            return inserted;
        }

        public ObservableCollection<Dados.Entidades.CondPagtos> ListarCondPgto()
        {
            ObservableCollection<Dados.Entidades.CondPagtos> listaCondPgto = new ObservableCollection<Dados.Entidades.CondPagtos>(_Dados._conexao.Table<Dados.Entidades.CondPagtos>());
            return listaCondPgto;
        }

        public Dados.Entidades.CondPagtos ListarCondPgto(string GroupNum)
        {
            ObservableCollection<Dados.Entidades.CondPagtos> listaCondPgto = new ObservableCollection<Dados.Entidades.CondPagtos>(_Dados._conexao.Table<Dados.Entidades.CondPagtos>());
            return listaCondPgto.Where(T0 => T0.GroupNum.Equals(Convert.ToInt32(GroupNum))).FirstOrDefault();
        }

        public void SetDados(AcessarDados dados)
        {
            _Dados = dados;
        }

        public int UpdateCondPgto(Dados.Entidades.CondPagtos condPgtos)
        {
            int updated = 0;
            updated = _Dados.Update<Dados.Entidades.CondPagtos>(condPgtos);
            return updated;
        }
    }
}
