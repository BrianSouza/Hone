using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hone.Dados.Services;
using Hone.Entidades;
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


        public ObservableCollection<Parceiro> ListarParceiros()
        {
            ObservableCollection<Parceiro> pns = new ObservableCollection<Parceiro>(_conexao.Table<Parceiro>());
            return pns;
        }

        public void CriarTabelas()
        {
            _conexao.CreateTable<Parceiro>();
            _conexao.CreateTable<FormaPgto>();
            _conexao.CreateTable<CondPagto>();
            _conexao.CreateTable<Item>();
            _conexao.CreateTable<Pedido>();
        }

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}
