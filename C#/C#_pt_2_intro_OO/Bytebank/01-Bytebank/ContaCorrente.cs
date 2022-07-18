//using _01_Bytebank;

namespace _01_Bytebank
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; } // Quando getters e setters não vão seguir nenhuma regra, pode-se simplificar dessa forma
        public int Agencia { get; set; } // digitar 'prop' seguido de dois tabs para criar modelo com getter e setter
        public int Conta { get; set; }
        public static int TotalDeContasCriadas { get; private set; }
        private double _saldo;

        public double Saldo
        {
            get
            {
                return this._saldo;
            }
            set
            { // 'value' é uma palavra reservada utilizada no contexto de setters
                if (value < 0) return;
                this._saldo = value;
            }
        }

        public ContaCorrente(int agencia, int conta, Cliente titular)
        {
            Agencia = agencia;
            Conta = conta;
            Titular = titular;

            ContaCorrente.TotalDeContasCriadas++;
        }

        public void Sacar(double valor)
        {
            if (this._saldo >= valor)
            {
                this._saldo -= valor;
                Console.WriteLine("Operação realizada com sucesso");
            }
            else
                Console.WriteLine("Saldo insuficiente");
        }

        public void Depositar(double valor)
        {
            this._saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (this._saldo >= valor)
            {
                this._saldo -= valor;
                contaDestino.Depositar(valor);
                Console.WriteLine("Operação realizada com sucesso");
            }
            else
                Console.WriteLine("Saldo insuficiente");
        }
    }
}