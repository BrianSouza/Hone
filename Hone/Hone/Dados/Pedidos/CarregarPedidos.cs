using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.Dados.Services;
using Hone.Entidades;
using Xamarin.Forms;

namespace Hone.Dados.Pedidos
{
    public class CarregarPedidos : ICarregarPedidos
    {
        ICrudFormaPgto crudFP = null;
        ICondPgtos crudCP = null;
        ICrudItens crudItem = null;
        ICrudPedidos crudPed = null;
        ICrudParceiros crudPN = null;

        public CarregarPedidos()
        {
            crudFP = DependencyService.Get<ICrudFormaPgto>();
            crudCP = DependencyService.Get<ICondPgtos>();
            crudItem = DependencyService.Get<ICrudItens>();
            crudPed = DependencyService.Get<ICrudPedidos>();
        }

        public Pedido CarregarPedido(int idPedido)
        {
            Pedido pedido = null;
            using (AcessarDados _Dados = new AcessarDados())
            {
                SetDados(_Dados);

                Dados.Entidades.Pedidos dadosPedido = crudPed.ListarPedido(idPedido);
                ObservableCollection<Dados.Entidades.Itens> dadosItens = crudItem.ListarItens(idPedido);
                Dados.Entidades.CondPagtos dadosCondPgto = crudCP.ListarCondPgto(dadosPedido.CondPagto);
                Dados.Entidades.FormaPgtos dadosFormPgto = crudFP.ListarFormaPgto(dadosPedido.FormaPgto);
                Dados.Entidades.Parceiros dadosPN = crudPN.ListarParceiro(dadosPedido.CardCode);

                CondPagto condPgto = GetCondicaoPagamento(dadosCondPgto);
                Hone.Entidades.FormaPgto frmPgto = GetFormaPagamento(dadosFormPgto);

                Parceiro pn = GetParceiroDeNegocio(dadosPN);
                ObservableCollection<Item> itens = GetItensDoPedido(dadosItens);

                pedido = GetPedido(dadosPedido, condPgto, frmPgto, pn, itens);

            }
            return pedido;
        }

        private Pedido GetPedido(Entidades.Pedidos dadosPedido, CondPagto condPgto, Hone.Entidades.FormaPgto frmPgto, Parceiro pn, ObservableCollection<Item> itens)
        {
            if (dadosPedido == null)
                throw new NullReferenceException("Não foi encontrado o pedido.");

            Pedido pedido = new Pedido();
            pedido.CondPagto = condPgto;
            pedido.DtCadastro = dadosPedido.DtCadastro;
            pedido.DtEntrega = dadosPedido.DtEntrega;
            pedido.FormaPgto = frmPgto;
            pedido.Id = dadosPedido.Id;
            pedido.Itens = itens;
            pedido.Parceiro = pn;
            return pedido;
        }

        private ObservableCollection<Item> GetItensDoPedido(ObservableCollection<Entidades.Itens> dadosItens)
        {
            if (dadosItens == null || dadosItens.Count == 0)
                throw new NullReferenceException("Não foram encontrados itens para o pedido.");

            ObservableCollection<Item> itens = new ObservableCollection<Item>();
            foreach (var item in dadosItens)
            {
                Item itm = new Item();
                itm.ItemCode = item.ItemCode;
                itm.ItemName = item.ItemName;
                itm.Quantidade = item.Quantidade;
                itm.ValorUnit = item.ValorUnit;

                itens.Add(itm);
            }

            return itens;
        }

        private Parceiro GetParceiroDeNegocio(Entidades.Parceiros dadosPN)
        {
            if (dadosPN == null)
                throw new NullReferenceException("Não foi encontrado nenhum parceiro.");

            Parceiro pn = new Parceiro();
            pn.Bairro = dadosPN.Bairro;
            pn.CardCode = dadosPN.CardCode;
            pn.CardName = dadosPN.CardName;
            pn.Cep = dadosPN.Cep;
            pn.Cidade = dadosPN.Cidade;
            pn.Estado = dadosPN.Estado;
            pn.IdMobile = dadosPN.IdMobile;
            pn.Logradouro = dadosPN.Logradouro;
            pn.NumDocumento = dadosPN.NumDocumento;
            pn.NumeroLog = dadosPN.NumeroLog;
            pn.Telefone = dadosPN.Telefone;
            pn.TipoDocumento = dadosPN.TipoDocumento;
            pn.TipoParceiro = dadosPN.TipoParceiro;
            return pn;
        }

        private Hone.Entidades.FormaPgto GetFormaPagamento(Entidades.FormaPgtos dadosFormPgto)
        {
            if (dadosFormPgto == null)
                throw new NullReferenceException("Não foi encontrado nenhuma forma de pagamento.");

            Hone.Entidades.FormaPgto frmPgto = new Hone.Entidades.FormaPgto();
            frmPgto.Descript = dadosFormPgto.Descript;
            frmPgto.PayMethCod = dadosFormPgto.PayMethCod;
            frmPgto.Type = dadosFormPgto.Type;
            return frmPgto;
        }

        private CondPagto GetCondicaoPagamento(Entidades.CondPagtos dadosCondPgto)
        {
            if (dadosCondPgto == null)
                throw new NullReferenceException("Não foi encontrado condição de pagamento.");

            CondPagto condPgto = new CondPagto();
            condPgto.GroupNum = dadosCondPgto.GroupNum;
            condPgto.PymntGroup = dadosCondPgto.PymntGroup;
            return condPgto;
        }

        private void SetDados(AcessarDados _Dados)
        {
            crudCP.SetDados(_Dados);
            crudFP.SetDados(_Dados);
            crudItem.SetDados(_Dados);
            crudPed.SetDados(_Dados);
        }

        public ObservableCollection<Pedido> CarregarPedidoPorCliente(string cardCode)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Pedido> CarregarTodosPedidos()
        {
            ObservableCollection<Pedido> pedidos = null;
            using (AcessarDados _Dados = new AcessarDados())
            {
                SetDados(_Dados);

                ObservableCollection<Dados.Entidades.Pedidos> dadosPedidos = crudPed.ListarPedidos();
                ObservableCollection<Dados.Entidades.Itens> dadosItens = crudItem.ListarItens();
                ObservableCollection<Dados.Entidades.CondPagtos> dadosCondPgtos = crudCP.ListarCondPgto();
                ObservableCollection<Dados.Entidades.FormaPgtos> dadosFormPgtos = crudFP.ListarFormasPgto();
                ObservableCollection<Dados.Entidades.Parceiros> dadosPNs = crudPN.ListarParceiros();

                pedidos = new ObservableCollection<Pedido>();

                foreach (var pedido in dadosPedidos)
                {
                    Pedido ped = new Pedido();

                    var dadosCondPgto = dadosCondPgtos.Where(T0 => T0.GroupNum.Equals(pedido.CondPagto)).FirstOrDefault();
                    CondPagto condPgto = GetCondicaoPagamento(dadosCondPgto);

                    var dadosFormPgto = dadosFormPgtos.Where(T0 => T0.PayMethCod.Equals(pedido.FormaPgto)).FirstOrDefault();
                    Hone.Entidades.FormaPgto frmPgto = GetFormaPagamento(dadosFormPgto);

                    var dadosPN = dadosPNs.Where(T0 => T0.CardCode.Equals(pedido.CardCode)).FirstOrDefault();
                    Parceiro pn = GetParceiroDeNegocio(dadosPN);

                    var dadosItensPed = new ObservableCollection<Dados.Entidades.Itens>(dadosItens.Where(T0 => T0.IdPedido.Equals(pedido.Id)));
                    ObservableCollection<Item> itens = GetItensDoPedido(dadosItensPed);

                    ped = GetPedido(pedido, condPgto, frmPgto, pn, itens);

                    pedidos.Add(ped);
                }
            }
            return pedidos;
        }
    }
}
