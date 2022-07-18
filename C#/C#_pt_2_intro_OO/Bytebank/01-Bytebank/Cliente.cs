using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Bytebank
{
    public class Cliente
    {
        public string Nome { get; set; }
        public int Cpf { get; set; }

        public Cliente(string nome, int cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }
    }
}
