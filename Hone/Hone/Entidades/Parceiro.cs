using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hone.Entidades
{
    public class Parceiro
    {
        public string CardCode { get; set; }

        public string CardName { get; set; }

        public string PhoneCardCode { get; set; }

        public string TipoParceiro { get; set; }

        public string TipoDocumento { get; set; }
        
        public string NumDocumento { get; set; }
        
        public string Logradouro { get; set; }
        
        public string NumeroLog { get; set; }
        
        public string Bairro { get; set;}

        public string Cidade { get; set; }

        public string Estado { get; set; }
        
        public string Cep { get; set; }

        public string Telefone { get; set; }
    }
}
