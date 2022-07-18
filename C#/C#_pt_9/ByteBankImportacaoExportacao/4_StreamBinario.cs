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
        public static void EscreverBinario()
        {
            using (var fs = new FileStream("testeBinario.txt", FileMode.Create))
            using (var escritor = new BinaryWriter(fs))
            {
                escritor.Write(123); // Agência
                escritor.Write(4567); // Conta
                escritor.Write(999.90); // Saldo
                escritor.Write("Lucas"); // Titular
            }
        }

        public static void LerBinario()
        {
            using (var fs = new FileStream("testeBinario.txt", FileMode.Open))
            using (var leitor = new BinaryReader(fs))
            {
                var agencia = leitor.ReadInt32();
                var conta = leitor.ReadInt32();
                var saldo = leitor.ReadDouble();
                var titular = leitor.ReadString();
                Console.WriteLine($"{agencia}/{conta} {titular} {saldo}");
            }
        }
    }
}
