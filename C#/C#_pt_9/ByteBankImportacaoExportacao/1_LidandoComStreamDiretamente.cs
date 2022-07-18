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
        static void LidandoComStream()
        {
            var enderecoArquivo = "contas.txt";

            // Açúcar sintático 'using' pode ser utilizado em qualquer classe com interface IDisposable
            // ao concluir as instruções, ele executa o método dispose 'fluxoDoArquivo.close()' 
            using (var fluxoDoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024]; // 1 kb;
                var numeroDeBytesLidos = -1;

                while (numeroDeBytesLidos != 0)
                {
                    // Retorna o número de bytes lidos no buffer
                    // quando reitera, o valor de buffer adiciona o valor de 'buffer.Length - 1'
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, buffer.Length);
                    EscreverBuffer(buffer, numeroDeBytesLidos);
                }
            }
            Console.ReadLine();
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var utf8 = new UTF8Encoding();
            var texto = utf8.GetString(buffer, 0, bytesLidos);
            Console.Write(texto);
        }
    }
}
