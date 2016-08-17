
using SQLite.Net.Attributes;

namespace Hone.Entidades
{
    public class Parceiro
    {
        [PrimaryKey, AutoIncrement]
        public int IdMobile { get; set; }
        public string CardCode { get; set; }

        public string CardName { get; set; }

        [NotNull]
        public string TipoParceiro { get; set; }
        [NotNull]
        public string TipoDocumento { get; set; }
        [NotNull]
        public string NumDocumento { get; set; }

        public string Logradouro { get; set; }

        public string NumeroLog { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
        [NotNull]
        public string Cep { get; set; }

        public string Telefone { get; set; }
    }
}
