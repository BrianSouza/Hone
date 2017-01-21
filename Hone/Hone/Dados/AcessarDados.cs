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
        SQLite.Net.SQLiteConnection _conexao;
        public AcessarDados()
        {
            var config = DependencyService.Get<IConfigDados>();
            _conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "HoneDB.db3"));
        }

        public void Insert<T>(T tabela)
        {
            _conexao.Insert(tabela);
        }

        public void Update<T>(T tabela)
        {
            _conexao.Update(tabela);
        }
        public void Delete<T>(T tabela)
        {
            _conexao.Delete(tabela);
        }


        public ObservableCollection<Parceiros> ListarParceiros()
        {
            ObservableCollection<Parceiros> pns = new ObservableCollection<Parceiros>(_conexao.Table<Parceiros>());
            return pns;
        }

        public void CriarTabelas()
        {
            _conexao.CreateTable<Parceiros>();
            _conexao.CreateTable<FormaPgto>();
            _conexao.CreateTable<CondPagto>();
            _conexao.CreateTable<Items>();
            _conexao.CreateTable<Pedidos>();
        }

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}
