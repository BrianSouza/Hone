using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Dados.Entidades;
using Hone.Dados.Services;
using Hone.Services;
using Xamarin.Forms;

namespace Hone.Dados.Pedidos
{
    public class SalvarPedido : ISalvarPedido
    {
        private readonly ICrudItens crudItens = null;
        private readonly ICrudPedidos crudPedidos = null;
        private readonly IMessageServices _Message = null; 

        public SalvarPedido()
        {
            crudItens = DependencyService.Get<ICrudItens>();
            crudPedidos = DependencyService.Get<ICrudPedidos>();
            _Message = DependencyService.Get<IMessageServices>();
        }
        public int Salvar(Entidades.Pedidos pedido, List<Itens> itens)
        {
            int id = 0;
            using (AcessarDados dados = new AcessarDados())
            {
                try
                {
                    crudItens.SetDados(dados);
                    crudPedidos.SetDados(dados);
                    int idPedido = 0;
                    dados._conexao.BeginTransaction();
                    if (pedido.Id == 0)
                    {
                        idPedido = crudPedidos.InsertPedido(pedido);
                        if (idPedido == 0)
                            throw new Exception("Não foi possível inserir o pedido.");

                        foreach (var item in itens)
                        {
                            item.IdPedido = idPedido;
                            int idLinha = crudItens.InsertItens(item);

                            if (idLinha == 0)
                                throw new Exception($"Não foi possível inserir a linha do item {item.ItemCode}.");
                        }
                    }
                    else if (pedido.Id > 0)
                    {
                        idPedido = crudPedidos.UpdatePedido(pedido);
                        if (idPedido == 0)
                            throw new Exception("Não foi possível inserir o pedido.");

                        foreach (var item in itens)
                        {
                            int idLinha = crudItens.UpdateItens(item);

                            if (idLinha == 0)
                                throw new Exception($"Não foi possível inserir a linha do item {item.ItemCode}.");
                        }
                    }
                    else
                        throw new Exception("O número do pedido não foi informado.");
                    id = idPedido;
                    dados._conexao.Commit();
                }
                catch(Exception ex) 
                {
                    dados._conexao.Rollback();
                    _Message.ShowAsync("Pedidos", ex.Message);
                }  
            }
            return id;
        }
    }
}
