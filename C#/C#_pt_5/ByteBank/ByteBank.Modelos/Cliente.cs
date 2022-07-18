using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Profissao { get; set; }

        public override bool Equals(object obj)
        {
            // Cliente outroCliente = (Cliente)obj; // lança exceção caso não seja possível a conversão
            Cliente outroCliente = obj as Cliente;  // retorna Null caso não seja possível a conversão
            
            if (outroCliente == null) return false;
            return this.Nome == outroCliente.Nome && this.CPF == outroCliente.CPF && this.Profissao == outroCliente.Profissao;
        }
    }
}
