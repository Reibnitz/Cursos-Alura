using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
        /// <summary>
        /// Define uma Conta Corrente do banco ByteBank.
        /// </summary>
    public class ContaCorrente : IComparable
    {
        private static int TaxaOperacao;

        public static int TotalDeContasCriadas { get; private set; }

        public Cliente Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public int Numero { get; }
        public int Agencia { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        /// <summary>
        /// Cria uma instância de Conta Corrente com os argumentos utilizados.
        /// </summary>
        /// <param name="agencia">Representa o valor da propriedade <see cref="Agencia"/> e deve possuir um valor maior que zero.</param>
        /// <param name="numero">Representa o valor da propriedade <see cref="Numero"/> e deve possuir um valor maior que zero.</param>
        /// <exception cref="ArgumentException"></exception>
        public ContaCorrente(int agencia, int numero)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if (numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        /// <summary>
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Saldo"/>.
        /// </summary>
        /// <param name="valor">Representa o valor do saque. Deve ser maior do que zero e menor do que o <see cref="Saldo"/>.</param>
        /// <exception cref="ArgumentException">Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/></exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando o valor de <see cref="Saldo"/> é menor do que o do parâmetro <paramref name="valor"/>.</exception>
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }

            contaDestino.Depositar(valor);
        }

        /// <summary>
        /// Retorna os valores de <see cref="Numero"/>, <see cref="Agencia"/> e <see cref="Saldo"/>.
        /// </summary>
        public override string ToString()
        {
            return $"Número: {Numero}, Agência: {Agencia}, Saldo {Saldo}";
        }

        /// <summary>
        /// Verifica se um objeto do tipo Conta Corrente possui os mesmo valores de <see cref="Numero"/> e <see cref="Agencia"/> que a Conta Corrente de referência.
        /// </summary>
        /// <param name="contaAVerificar">Conta Corrente a ser verificada.</param>
        /// <returns>True caso seja verdadeiro, False caso seja falso.</returns>
        public override bool Equals(object contaAVerificar)
        {
            ContaCorrente outraConta = contaAVerificar as ContaCorrente;
            if (outraConta == null) return false;

            return this.Numero == outraConta.Numero && this.Agencia == outraConta.Agencia;
        }

        public int CompareTo(object obj)
        {
            var contaComparacao = obj as ContaCorrente;
            if (contaComparacao == null) return -1;

            return this.Numero.CompareTo(contaComparacao.Numero);
        }
    }

}
