using System;
using System.Collections.ObjectModel;
using System.Linq;
using Hone.Dados.Entidades;
using Hone.Dados.Services;
using Xamarin.Forms;

namespace Hone.Dados
{
    public class AcessarDados : IDisposable, IAcessarDados
    {
        public SQLite.Net.SQLiteConnection _conexao;
        public AcessarDados()
        {
            var config = DependencyService.Get<IConfigDados>();
            _conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "HoneDB.db3"));
        }

        public int Insert<T>(T tabela)
        {
            return _conexao.Insert(tabela);
        }

        public int Update<T>(T tabela)
        {
           return _conexao.Update(tabela);
        }
        public int Delete<T>(T tabela)
        {
            return _conexao.Delete(tabela);
        }


        public ObservableCollection<Parceiros> ListarParceiros()
        {
            ObservableCollection<Parceiros> pns = new ObservableCollection<Parceiros>(_conexao.Table<Parceiros>());
            return pns;
        }

        public void CriarTabelas()
        {
            _conexao.CreateTable<Parceiros>();
            _conexao.CreateTable<FormaPgtos>();
            _conexao.CreateTable<CondPagtos>();
            _conexao.CreateTable<Itens>();
            _conexao.CreateTable<Entidades.Pedidos>();
        }

       

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}
