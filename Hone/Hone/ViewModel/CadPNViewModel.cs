using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hone.Entidades;
using Hone.Services;
using Xamarin.Forms;

namespace Hone.ViewModel
{
    public class CadPNViewModel : BaseViewModel
    {
        public CadPNViewModel()
        {
            ListarEstados();
            this.Salvar = new Command(this.SalvarPN);
            VisibleCPF = false;
            VisibleCNPJ = false;
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
        #endregion

        #region Propriedades
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
                _tipoParc = value;
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
                _tipoDoc = value;
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
                _descricao = value;
                this.Notify("Descricao");
            }
        }

        public string DocumentoCPF
        {
            get { return _DocumentoCPF; }
            set
            {
                _DocumentoCPF = value;
                this.Notify("DocumentoCPF");
            }
        }
        public string DocumentoCNPJ
        {
            get { return _DocumentoCNPJ; }
            set
            {
                _DocumentoCNPJ = value;
                this.Notify("DocumentoCNPJ");
            }
        }

        public string Endereco
        {
            get { return _endereco; }
            set
            {
                _endereco = value;
                this.Notify("Endereco");
            }
        }

        public string Num
        {
            get { return _num; }
            set
            {
                _num = value;
                this.Notify("Num");
            }
        }

        public string Cidade
        {
            get { return _cidade; }
            set
            {
                _cidade = value;
                this.Notify("Cidade");
            }
        }

        public string Bairro
        {
            get { return _bairro; }
            set
            {
                _bairro = value;
                this.Notify(Bairro);
            }
        }

        public string Estado
        {
            get { return _estado; }
            set
            {
                _estado = value;
                this.Notify("Estado");
            }
        }

        public string Telefone
        {
            get { return _Telefone; }
            set
            {
                _Telefone = value;
                this.Notify("Telefone");
            }
        }

        public string CEP
        {
            get { return _Telefone; }
            set
            {
                _Telefone = value;
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
                _Navigation.NavigateToMain();

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
    }

}
