using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void UsarFileStream()
        {
            var localDoArquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(localDoArquivo, FileMode.Open))
            // Ao usar dois usings seguidos, o segundo não precisa ficar dentro de chaves
            using (var leitor = new StreamReader(fluxoDoArquivo))
            {
                // Método EndOfStream retorna true quando o 'leitor' atingir o fim do arquivo
                while (!leitor.EndOfStream)
                {
                    // var textoCompleto = leitor.ReadToEnd(); // Lê o arquivo inteiro antes de prosseguir. Usar com cuidado
                    var linha = leitor.ReadLine();
                    var conta = ConverterStringParaCC(linha);
                    var msg = $"Titular: {conta.Titular.Nome}, Conta: {conta.Numero}, Ag: {conta.Agencia}, Saldo: {conta.Saldo}";

                    Console.WriteLine(msg);
                }
            }

            Console.ReadLine();
        }

        static ContaCorrente ConverterStringParaCC(string linha)
        {
            string[] campos = linha.Split(' ');

            var agencia = int.Parse(campos[0]);
            var conta = int.Parse(campos[1]);
            var saldo = double.Parse(
                campos[2].Replace('.', ',')
            );
            var titular = campos[3];

            var cliente = new Cliente();
            cliente.Nome = titular;

            var resultado = new ContaCorrente(agencia, conta);
            resultado.Titular = cliente;
            resultado.Depositar(saldo);

            return resultado;
        }
    }
}