using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    // 'partial class' indica que essa mesma classe está dividida em diferentes arquivos
    partial class Program
    {
        static void Main(string[] args)
        {
            EscreverBinario();

            Console.ReadLine();
        }
    }
}
