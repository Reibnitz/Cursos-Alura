using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarregarContas();
            }
            catch (Exception)
            {
                Console.WriteLine("Catch no método MAIN");
            }

            Console.ReadLine();
        }

        public static void CarregarContas()
        {
            using (LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt")) // using requer que a classe implemente a interface IDisposable
            {                                                                  // IDisposable requer método Dispose() que executa como finally, mesmo com exceção
                leitor.LerProximaLinha();                                      
            }

            //LeitorDeArquivo leitor = null;
            //try
            //{
            //    leitor = new LeitorDeArquivo("contas.txt");

            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //}
            //catch (IOException ex)
            //{
            //    Console.WriteLine("Exceção do tipo IOException capturada e tratada.");
            //}
            //finally
            //{
            //    if (leitor != null)
            //    {
            //    leitor.Fechar();
            //    }
            //}
        }

        public static void TestarException()
        {
            try
            {
                ContaCorrente conta = new ContaCorrente(123, 4567);

                ContaCorrente conta2 = new ContaCorrente(987, 6543);
                conta2.Depositar(200);
                conta2.Transferir(500, conta);
                Console.WriteLine(conta2.Saldo);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OperacaoFinanceiraException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("*********** StackTrace da INNER EXCEPTION ***********");
                Console.WriteLine(ex.InnerException.StackTrace);
            }
        }

        public static void ChamarDivisao()
        {
            try
            {
                Console.WriteLine(Dividir(0));
            }
            catch (Exception ex) // é convenção chamar variável exception em blocos catch de 'ex'
            {
                Console.WriteLine("Exceção capturada em ChamarDivisao. Mensagem de erro: " + ex.Message);
            }
        }

        public static int Dividir(int divisor)
        {
            try
            {
                return 10 / divisor;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exceção capturada em Dividir e propagada através do Throw");
                throw; // sem 'throw' não seria compilável porque Dividir espera um retorno
            }
        }
    }
}
