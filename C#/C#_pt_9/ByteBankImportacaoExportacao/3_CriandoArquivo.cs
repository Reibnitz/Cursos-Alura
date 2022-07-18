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
        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaComoString = "375,4644,2483.13,Jonatan";
                var encoding = Encoding.UTF8;

                var bytes = encoding.GetBytes(contaComoString);

                fluxoDeArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        static void CriarArquivoComWriter()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            // 'Enconding.UTF8' não precisa ser explicitado como parâmetro. Nesse caso, usa-se 'Encoding.Default'
            using (var escritor = new StreamWriter(fluxoDeArquivo, Encoding.UTF8))
            {
                var contaComoString = "375,4644,2483.13,João";
                escritor.Write(contaComoString);
                // O método StreamWriter.Write funciona com um buffer. O arquivo só é efetivamente atualizado quando
                // a quantidade de bytes excede o buffer. Para forçar o arquivo ser escrito, usa-se o método
                // StreamWriter.Flush();
            }
        }
    }
}