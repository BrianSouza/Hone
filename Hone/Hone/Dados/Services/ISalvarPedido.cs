using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hone.Dados.Services
{
    interface ISalvarPedido
    {
        int Salvar(Entidades.Pedidos pedido, Entidades.Itens itens);
    }
}
