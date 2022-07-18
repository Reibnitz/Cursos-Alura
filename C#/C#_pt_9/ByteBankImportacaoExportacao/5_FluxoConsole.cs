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
        public static void LerConsole()
        {

            using (var console = Console.OpenStandardInput())
            using (var fs = new FileStream("textoConsole.txt", FileMode.Create))
            {
                var buffer = new byte[1024];

                while (true)
                {
                    var bytesLidos = console.Read(buffer, 0, buffer.Length);
                    
                    fs.Write(buffer, 0, bytesLidos);
                    fs.Flush();

                    Console.WriteLine($"Número de bytes lidos: {bytesLidos}");
                    
                }
            }

        }
    }
}
