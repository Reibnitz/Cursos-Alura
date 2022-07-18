using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class ContaCorrente
    {
        public static double TaxaOperacao { get; private set; }
        public static int TotalDeContasCriadas { get; private set; }
        public Cliente Titular { get; set; }
        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public int Agencia { get; } // Sem setter, a propriedade fica somente leitura
        public int Numero { get; }
        public double Saldo { get; private set; }

        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)
            {
                throw new ArgumentException("O argumento de Agência deve ser maior do que zero.", nameof(agencia));
            }
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento de Número de conta deve ser maior do que zero.", nameof(numero));
            }
            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }


        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para esta operação.", nameof(valor));
            }

            if (this.Saldo < valor)
            {
                this.ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(this.Saldo, valor);
            }

            this.Saldo -= valor;
            
        }

        public void Depositar(double valor)
        {
            this.Saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            try
            {
            this.Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                this.ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não pode ser realizada", ex); // Repassa a exception como innerException
                // throw;  throw vazio (sem objeto) repassa a exception preservando a stacktrace
            }
            contaDestino.Depositar(valor);
        }
    }
}
