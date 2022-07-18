using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {
        public double Saldo { get; }
        public double ValorOperacao { get; }

        public SaldoInsuficienteException() { }
        
        public SaldoInsuficienteException(string mensagem) : base(mensagem) { }

        public SaldoInsuficienteException(string mensagem, Exception excecaoInterna) : base (mensagem, excecaoInterna) { }

        public SaldoInsuficienteException(double saldo, double valorOperacao) : this($"O saldo de R$ {saldo} é insuficiente para realizar esta operação de R$ {valorOperacao}.")
        {
            this.Saldo = saldo;
            this.ValorOperacao = valorOperacao;
        }
    }
}
