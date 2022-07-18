using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank
{
    public class ExtratorValorAgumentosURL
    {
        readonly string _argumentos;
        public string URL { get; }

        public ExtratorValorAgumentosURL(string url) // atalho 'ctor' seguido de 2 tab's
        {
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento URL não pode ser null nem vazio.", nameof(url));
            }

            this.URL = url.ToLower();

            int indiceInterrogacao = url.IndexOf("?");
            this._argumentos = url.Substring(indiceInterrogacao + 1);
        }

        public string GetValor(string nomeParametro)
        {
            string termo = nomeParametro.ToLower() + "=";
            int indiceTermo = _argumentos.IndexOf(termo);
            
            string resultado = _argumentos.Substring(indiceTermo + termo.Length);
            int indiceEComercial = resultado.IndexOf("&");

            if (indiceEComercial == -1) // indexOf retorna -1 caso não encontre o valor
            {
                return resultado;
            }
            else
            {
                return resultado.Remove(indiceEComercial);
            }
        }
    }
}
