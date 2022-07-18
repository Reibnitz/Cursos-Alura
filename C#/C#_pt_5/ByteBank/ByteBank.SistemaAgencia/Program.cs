using Bytebank;
using ByteBank.Modelos;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var lista = new List<int>();
            lista.AdicionarVarios(4, 3, 2, 1);
            lista.Sort();

            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }

            var contas = new List<ContaCorrente>(){
                new ContaCorrente(789, 98981),
                new ContaCorrente(639, 65171),
                new ContaCorrente(981, 24352),
                null,
                new ContaCorrente(496, 32421),
                new ContaCorrente(503, 59571),
                new ContaCorrente(214, 81369),
                null
            };

            // contas.Sort(); // Método implementado na classe ContaCorrente implementando interface IComparable
            // Método Sort altera a ordem da lista original
            // contas.Sort(new ComparadorCCPorAgencia()); // Método com interface IComparer na classe ComparadorCCPorAgencia

            var contasNaoNulas = contas.Where(conta => conta != null);

            // Método OrderBy retorna uma nova lista ordenada, sem afetar a original
            var contasOrdenadas = contasNaoNulas.OrderBy(conta =>
            {
                if (conta == null) return int.MaxValue;
                return conta.Numero;
            });

            foreach (var conta in contasOrdenadas)
            {
                Console.WriteLine(conta);
            }

            Console.ReadLine();
        }

        static void TestesListaCC()
        {
            ListaContaCorrente lista = new ListaContaCorrente();
            ContaCorrente conta1 = new ContaCorrente(789, 45464);
            lista.Adicionar(
                new ContaCorrente(789, 98981),
                new ContaCorrente(789, 65171),
                new ContaCorrente(789, 24352),
                new ContaCorrente(789, 32421),
                new ContaCorrente(789, 59571),
                new ContaCorrente(789, 81369)
            );
            lista.Adicionar(conta1);

            lista.ImprimirLista();
            Console.WriteLine("--------");

            lista.Remover(conta1);
            lista.ImprimirLista();

            Console.WriteLine("--------");
            Console.WriteLine(lista[1]);
        }

        static void SomarNumeros(int[] itens)
        {
            for (int i = 0; i < itens.Length - 1; i += 2)
            {
                int primeiroNumero = itens[i];
                int segundoNumero = itens[i + 1];
                int soma = primeiroNumero + segundoNumero;

                Console.WriteLine($"{primeiroNumero} + {segundoNumero} = {soma}");
            }
        }

        static void TestesString()
        {
            string url = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            ExtratorValorAgumentosURL extratorDeValores = new ExtratorValorAgumentosURL(url);

            string termoBuscado = "moedaDestino";
            Console.WriteLine("Valor de moeda destino: " + extratorDeValores.GetValor(termoBuscado)); // Valor de moeda destino: dolar

            string texto = "Entre em contato conosco através do número 3232-3232";
            string padrao = @"\d{4,5}-?\d{4}"; // usar @ antes das aspas para reconhecer \
            Match resultado = Regex.Match(texto, padrao);
            Console.WriteLine(resultado.Value); // 3232-3232
        }

        static void TesteObjetos()
        {
            ContaCorrente conta = new ContaCorrente(123, 4567);
            Console.WriteLine(conta); // Chamando WriteLine em um objeto executa o método ToString
                                      // Método ToString é nativo de tipos objeto e pode ser sobrescrito. Ver classe


            Cliente cliente1 = new Cliente();
            cliente1.Nome = "Carlos";
            cliente1.Profissao = "Desenvolvedor";
            cliente1.CPF = "111.222.333-44";

            Cliente cliente2 = new Cliente();
            cliente2.Nome = "Carlos";
            cliente2.Profissao = "Desenvolvedor";
            cliente2.CPF = "111.222.333-44";

            Console.WriteLine("'cliente1 == cliente2' retorna: " + (cliente1 == cliente2)); // False
            Console.WriteLine("'cliente1.Equals(cliente2)' retorna: " + cliente1.Equals(cliente2)); // True
                                                                                                    // Retornaria False se não tivesse sido sobrescrito. Ver classe.
        }

        static void TesteHumanizer()
        {
            DateTime dataFimPagamento = new DateTime(2022, 5, 31);
            DateTime dataHoje = DateTime.Now;

            Console.WriteLine(dataHoje);

            TimeSpan diferenca = dataFimPagamento - dataHoje;
            string mensagem = $"Vencimento em {TimeSpanHumanizeExtensions.Humanize(diferenca)}";

            Console.WriteLine(mensagem);
        }
    }
}
