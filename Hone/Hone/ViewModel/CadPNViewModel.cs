using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Hone.Dados;
using Hone.Entidades;
using Hone.View;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Hone.ViewModel
{
    public class CadPNViewModel : BaseViewModel
    {
        public CadPNViewModel()
        {
            ListarEstados();
            ListarTipoPN();
            ListarTipoDoc();
            this.Salvar = new Command(this.SalvarPN);
            VisibleCPF = false;
            VisibleCNPJ = false;
            CarregarParceiroSelecionado();
            Parceiro parceiro = new Parceiro();
        }

        #region Variaveis
        private string _descricao;
        private string _tipoDoc; //TODO: fazer enum para o tipo de documento
        private int _TipoDocID;
        private ObservableCollection<string> _lstTipoDoc;
        private string _DocumentoCPF;
        private string _DocumentoCNPJ;
        private string _tipoParc;
        private int _TipoParcID;
        private ObservableCollection<string> _lstTipoParc;
        private string _endereco;
        private string _num;
        private string _cidade;
        private string _bairro;
        private string _estado;
        private string _Telefone;
        private ObservableCollection<Estados> _ListaEstados;
        private Estados _SelectedEstado;
        private int estadoID;
        private bool visibleCNPJ;
        private bool visibleCPF;
        private int _idMobile;
        private string _CEP;
        #endregion

        #region Propriedades
        public int IdMobile
        {
            get { return _idMobile; }
            set { _idMobile = value; }
        }
        public bool VisibleCNPJ
        {
            get
            {
                return visibleCNPJ;
            }
            set
            {
                visibleCNPJ = value;
                if (visibleCNPJ)
                {
                    DocumentoCPF = string.Empty;
                }
                this.Notify("VisibleCNPJ");
            }
        }
        public bool VisibleCPF
        {
            get
            {
                return visibleCPF;
            }
            set
            {
                visibleCPF = value;
                if (visibleCPF)
                {
                    DocumentoCNPJ = string.Empty;
                }
                this.Notify("VisibleCPF");
            }
        }
        public int TipoParcID
        {
            get
            {
                return _TipoParcID;
            }
            set
            {
                _TipoParcID = value;
                _tipoParc = LstTipoParc[value];

                this.Notify("TipoParcID");
            }
        }
        public string TipoParc
        {
            get { return _tipoParc; }
            set
            {
                _tipoParc = value.ToUpper();
                this.Notify("TipoParc");
            }
        }
        public ObservableCollection<string> LstTipoParc
        {
            get
            {
                return _lstTipoParc;
            }
            set
            {
                _lstTipoParc = value;
                this.Notify("LstTipoParc");
            }
        }

        public int TipoDocID
        {
            get
            {
                return _TipoDocID;
            }
            set
            {
                _TipoDocID = value;
                TipoDoc = _lstTipoDoc[value];
                VisibleCNPJ = value == 1 ? true : false;
                VisibleCPF = value == 0 ? true : false;
                this.Notify("TipoDocID");
            }
        }

        public string TipoDoc
        {
            get { return _tipoDoc; }
            set
            {
                _tipoDoc = value.ToUpper();
                this.Notify("TipoDoc");
            }
        }

        public ObservableCollection<string> LstTipoDoc
        {
            get { return _lstTipoDoc; }
            set
            {
                _lstTipoDoc = value;
                this.Notify("LstTipoDoc");
            }
        }

        public int EstadoID
        {
            get { return estadoID; }
            set
            {
                estadoID = value;
                SelectedEstado = ListaEstados[value];
            }
        }

        public Estados SelectedEstado
        {
            get
            {
                return _SelectedEstado;
            }
            set
            {
                //TODO: Verificar se aqui vai dar erro ao retornar informação.
                _SelectedEstado = value;
                this.Notify("SelectedEstado");
            }
        }

        public ObservableCollection<Estados> ListaEstados
        {
            get
            {
                return _ListaEstados;
            }
            set
            {
                _ListaEstados = value;
                this.Notify("ListaEstados");
            }
        }

        public string Descricao
        {
            get { return _descricao; }
            set
            {
                _descricao = value.ToUpper();
                this.Notify("Descricao");
            }
        }

        public string DocumentoCPF
        {
            get { return _DocumentoCPF; }
            set
            {
                _DocumentoCPF = value.ToUpper();
                this.Notify("DocumentoCPF");
            }
        }
        public string DocumentoCNPJ
        {
            get { return _DocumentoCNPJ; }
            set
            {
                _DocumentoCNPJ = value.ToUpper();
                this.Notify("DocumentoCNPJ");
            }
        }

        public string Endereco
        {
            get { return _endereco; }
            set
            {
                _endereco = value.ToUpper();
                this.Notify("Endereco");
            }
        }

        public string Num
        {
            get { return _num; }
            set
            {
                _num = value.ToUpper();
                this.Notify("Num");
            }
        }

        public string Cidade
        {
            get { return _cidade; }
            set
            {
                _cidade = value.ToUpper();
                this.Notify("Cidade");
            }
        }

        public string Bairro
        {
            get { return _bairro; }
            set
            {
                _bairro = value.ToUpper();
                this.Notify("Bairro");
            }
        }

        public string Estado
        {
            get { return _estado; }
            set
            {
                _estado = value.ToUpper();
                this.Notify("Estado");
            }
        }

        public string Telefone
        {
            get { return _Telefone; }
            set
            {
                _Telefone = value.ToUpper();
                this.Notify("Telefone");
            }
        }

        public string CEP
        {
            get { return _CEP; }
            set
            {
                _CEP = value.ToUpper();
                this.Notify("CEP");
            }
        }


        #endregion

        #region Command
        public ICommand Salvar
        {
            get; set;
        }
        private void SalvarPN()
        {
            bool bValido = Validacoes();


            if (bValido)
            {
                SalvarParceiro();
                _Navigation.NavigateTo(new PNView());

            }

        }

        private bool Validacoes()
        {
            bool bValido = true;
            if (string.IsNullOrEmpty(Descricao))
            {

                _Message.ShowAsync("Atenção", "Informe a razão social.");
                bValido = false;
            }
            else if (string.IsNullOrEmpty(TipoParc))
            {
                _Message.ShowAsync("Atenção", "Informe o tipo do parceiro.");
                bValido = false;
            }
            else if (string.IsNullOrEmpty(TipoDoc))
            {
                _Message.ShowAsync("Atenção", "Informe se irá utilizar CNPJ ou CPF.");
                bValido = false;
            }
            else if (string.IsNullOrEmpty(DocumentoCPF) && string.IsNullOrEmpty(DocumentoCNPJ))
            {
                _Message.ShowAsync("Atenção", "Informe o número do documento");
                bValido = false;
            }
            else if (!string.IsNullOrEmpty(DocumentoCPF) && DocumentoCPF.Length < 11)
            {
                _Message.ShowAsync("Atenção", "O CPF deve ter 11 dígitos.");
                bValido = false;
            }
            else if (!string.IsNullOrEmpty(DocumentoCNPJ) && DocumentoCNPJ.Length < 14)
            {
                _Message.ShowAsync("Atenção", "O CNPJ deve ter 14 dígitos.");
                bValido = false;
            }
            else if (string.IsNullOrEmpty(Endereco))
            {
                _Message.ShowAsync("Atenção", "Informe o endereço.");
                bValido = false;
            }
            else if (string.IsNullOrEmpty(Cidade))
            {
                _Message.ShowAsync("Atenção", "Informe a cidade.");
                bValido = false;
            }
            else if (string.IsNullOrEmpty(CEP))
            {
                _Message.ShowAsync("Atenção", "Informe o CEP.");
                bValido = false;
            }
            else if (!string.IsNullOrEmpty(CEP) && CEP.Length < 8)
            {
                _Message.ShowAsync("Atenção", "O CEP deve ter 8 dígitos.");
                bValido = false;
            }

            return bValido;
        }
        #endregion

        private void ListarEstados()
        {
            _ListaEstados = new ObservableCollection<Estados>()
            {
                new Estados ("Acre","AC" ),
                new Estados ( "Alagoas",  "AL" ),
                new Estados ( "Amapá",  "AP" ),
                new Estados ("Amazonas", "AM"),
                new Estados ("Bahia", "BA" ),
                new Estados ("Ceará", "CE" ),
                new Estados ("Distrito Federal", "DF" ),
                new Estados ("Espírito Santo", "ES" ),
                new Estados ("Goiás", "GO" ),
                new Estados ("Maranhão", "MA" ),
                new Estados ("Mato Grosso", "MT" ),
                new Estados ("Mato Grosso do Sul", "MS"),
                new Estados ("Minas Gerais", "MG" ),
                new Estados ("Pará", "PA" ),
                new Estados ("Paraíba", "PB" ),
                new Estados ("Paraná", "PR" ),
                new Estados ("Pernambuco", "PE" ),
                new Estados ("Piauí", "PI" ),
                new Estados ("Rio de Janeiro","RJ" ),
                new Estados ("Rio Grande do Norte","RN" ),
                new Estados ("Rio Grande do Sul",  "RS" ),
                new Estados ("Rondônia", "RO" ),
                new Estados ("Roraima", "RR" ),
                new Estados ("Santa Catarina", "SC" ),
                new Estados ("São Paulo", "SP" ),
                new Estados ("Sergipe", "SE" ),
                new Estados ("Tocantins", "TO" )
            };
        }

        private void ListarTipoPN()
        {
            LstTipoParc = new ObservableCollection<string>();
            LstTipoParc.Add("Cliente");
            LstTipoParc.Add("Fornecedor");
        }

        private void ListarTipoDoc()
        {
            LstTipoDoc = new ObservableCollection<string>();
            LstTipoDoc.Add("CPF");
            LstTipoDoc.Add("CNPJ");
        }

        private void CarregarParceiroSelecionado()
        {
            var pnJson = _SaveAndLoad.LoadText("pn.txt");
            if (string.IsNullOrEmpty(pnJson) || pnJson == "null")
                return;

            Parceiro pnSelecionado = JsonConvert.DeserializeObject<Parceiro>(pnJson);
            this.IdMobile = pnSelecionado.IdMobile;
            this.Descricao = pnSelecionado.CardName;

            if (pnSelecionado.TipoDocumento == "CNPJ")
            {
                this.visibleCPF = false;
                this.visibleCNPJ = true;
                this.DocumentoCNPJ = pnSelecionado.NumDocumento;
            }
            else if (pnSelecionado.TipoDocumento == "CPF")
            {
                this.visibleCNPJ = false;
                this.visibleCPF = true;
                this.DocumentoCPF = pnSelecionado.NumDocumento;
            }
            this.Bairro = pnSelecionado.Bairro;
            this.CEP = pnSelecionado.Cep;
            this.Cidade = pnSelecionado.Cidade;
            this.Endereco = pnSelecionado.Logradouro;
            //this.Estado = pnSelecionado.Estado;
            this.Num = pnSelecionado.NumeroLog;
            this.SelectedEstado = ListaEstados.Where(t0 => t0.Sigla.Equals(pnSelecionado.Estado)).FirstOrDefault();
            this.Telefone = pnSelecionado.Telefone;
            this.TipoDoc = pnSelecionado.TipoDocumento;
            this.TipoParc = pnSelecionado.TipoParceiro;
        }

        private void SalvarParceiro()
        {
            Parceiro _parceiro = new Parceiro();
            _parceiro.IdMobile = this._idMobile;
            _parceiro.Bairro = this.Bairro;
            _parceiro.CardName = this.Descricao;
            _parceiro.Cep = this.CEP;
            _parceiro.Cidade = this.Cidade;
            _parceiro.Estado = this.Estado;
            _parceiro.Logradouro = this.Endereco;
            _parceiro.NumDocumento = string.IsNullOrEmpty(this._DocumentoCNPJ) ? this._DocumentoCPF : this._DocumentoCNPJ;
            _parceiro.NumeroLog = this.Num;
            _parceiro.Telefone = this.Telefone;
            _parceiro.TipoDocumento = this.TipoDoc;
            _parceiro.TipoParceiro = this.TipoParc;

            using (AcessarDados ad = new AcessarDados())
            {
                if (_parceiro.IdMobile == 0)
                    ad.Insert<Parceiro>(_parceiro);
                else if (_parceiro.IdMobile > 0)
                    ad.Update<Parceiro>(_parceiro);
            }
        }
    }

}
