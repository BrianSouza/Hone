using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Dados.Entidades;
using Hone.Dados.Services;

namespace Hone.Dados.FormaPgto
{
    internal class CrudFormaPgto : ICrudFormaPgto
    {
        AcessarDados _Dados = null;

        public int DeleteFormPgto(FormaPgtos formaPgtos)
        {
            int deleted = 0;
            deleted = _Dados.Delete<Dados.Entidades.FormaPgtos>(formaPgtos);
            return deleted;
        }

        public int InsertFormPgto(FormaPgtos formaPgtos)
        {
            int inserted = 0;
            inserted = _Dados.Insert<Dados.Entidades.FormaPgtos>(formaPgtos);
            return inserted;
        }

        public FormaPgtos ListarFormaPgto(string payMethCode)
        {
            ObservableCollection<FormaPgtos> listaFormasPgto = new ObservableCollection<FormaPgtos>(_Dados._conexao.Table<FormaPgtos>());
            return listaFormasPgto.Where(T0 => T0.PayMethCod.Equals(payMethCode)).FirstOrDefault();
        }

        public ObservableCollection<FormaPgtos> ListarFormasPgto()
        {
            ObservableCollection<FormaPgtos> listaFormasPgto = new ObservableCollection<FormaPgtos>(_Dados._conexao.Table<FormaPgtos>());
            return listaFormasPgto;
        }

        public void SetDados(AcessarDados dados)
        {
            _Dados = dados;
        }

        public int UpdateFormPgto(FormaPgtos formaPgtos)
        {
            int updated = 0;
            updated = _Dados.Update<Dados.Entidades.FormaPgtos>(formaPgtos);
            return updated;
        }
    }
}
