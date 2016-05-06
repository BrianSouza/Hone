using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hone
{
    public class Mask : IValueConverter
    {
        private enum TipoMascara
        {
            Phone,
            CEP,
            CNPJ,
            CPF
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string parametro = System.Convert.ToString(parameter).ToUpper();
            object mascara = null;
            switch (parametro)
            {
                case "PHONE":
                    mascara = Phone(value);
                    break;
                case "CEP":
                    mascara = CEP(value);
                    break;
                case "CNPJ":
                    mascara = CNPJ(value);
                    break;
                case "CPF":
                    mascara = CPF(value);
                    break;
            }

            return mascara;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        private object Phone(object value)
        {
            object mask = "";
            if (value != null)
            {
                string _value = value.ToString();
                _value = ReplaceMask(_value, TipoMascara.Phone);
                _value = LimitarString(12, _value);
                mask = _value;

                if (_value.Length == 11)
                {
                    string ddd = _value.Substring(0, 3);
                    string digInicial = _value.Substring(3, 4);
                    string digFinal = _value.Substring(7, 4);
                    mask = string.Format("({0}) {1}-{2}", ddd, digInicial, digFinal);
                    return mask;
                }
                else if (_value.Length == 12)
                {
                    string ddd = _value.Substring(0, 3);
                    string digInicial = _value.Substring(3, 5);
                    string digFinal = _value.Substring(8, 4);
                    mask = string.Format("({0}) {1}-{2}", ddd, digInicial, digFinal);
                    return mask;
                }
            }

            return mask;
        }

        private object CEP(object value)
        {
            object mask = "";
            if (value != null)
            {
                string _value = value.ToString();
                _value = ReplaceMask(_value, TipoMascara.CEP);
                _value = LimitarString(8, _value);
                mask = _value;
                if (_value.Length == 8)
                {
                    string digInicial = _value.Substring(0, 5);
                    string digFinal = _value.Substring(5, 3);
                    mask = string.Format("{0}-{1}", digInicial, digFinal);
                    return mask;
                }
            }

            return mask;
        }

        private object CNPJ(object value)
        {
            object mask = "";
            if (value != null)
            {
                string _value = value.ToString();
                _value = ReplaceMask(_value, TipoMascara.CNPJ);
                _value = LimitarString(14, _value);
                mask = _value;
                if (_value.Length == 14)
                {
                    string dig1 = _value.Substring(0, 2);
                    string dig2 = _value.Substring(2, 3);
                    string dig3 = _value.Substring(5, 3);
                    string dig4 = _value.Substring(8, 4);
                    string dig5 = _value.Substring(12, 2);
                    mask = $"{dig1}.{dig2}.{dig3}/{dig4}-{dig5}";
                    return mask;
                }
            }

            return mask;
        }

        private object CPF(object value)
        {
            object mask = "";
            if (value != null)
            {
                string _value = value.ToString();
                _value = ReplaceMask(_value, TipoMascara.CPF);
                _value = LimitarString(11, _value);
                mask = _value;
                if (_value.Length == 11)
                {
                    string dig1 = _value.Substring(0, 3);
                    string dig2 = _value.Substring(3, 3);
                    string dig3 = _value.Substring(6, 3);
                    string dig4 = _value.Substring(9, 2);
                    mask = $"{dig1}.{dig2}.{dig3}-{dig4}";
                    return mask;
                }
            }

            return mask;
        }

        private string LimitarString(int tamanho, string _value)
        {
            if (_value.Length <= tamanho)
            {
                return _value;
            }
            else
            {
                return _value.Substring(0, tamanho);
            }
        }

        private string ReplaceMask(string _value, TipoMascara tipoMascara)
        {
            string value = string.Empty;
            switch (tipoMascara)
            {
                case TipoMascara.Phone:
                    _value = _value.Replace("(", "");
                    _value = _value.Replace(")", "");
                    _value = _value.Replace(" ", "");
                    _value = _value.Replace("-", "");
                    value = _value;
                    break;
                case TipoMascara.CEP:
                    _value = _value.Replace("-", "");
                    value = _value;
                    break;
                case TipoMascara.CNPJ:
                    _value = _value.Replace(".", "");
                    _value = _value.Replace(@"/", "");
                    _value = _value.Replace("-", "");
                    value = _value;
                    break;
                case TipoMascara.CPF:
                    _value = _value.Replace(".", "");
                    _value = _value.Replace("-", "");
                    value = _value;
                    break;
            }
            return value;
        }
    }


}
