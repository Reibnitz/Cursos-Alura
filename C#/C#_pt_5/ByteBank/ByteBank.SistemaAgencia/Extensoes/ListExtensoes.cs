using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Extensoes
{
    public static class ListExtensoes
    { // Para criar método de extensão, se cria um método estático numa classe estática e referencia o this no constructor
        public static void AdicionarVarios<T>(this List<T> lista, params T[] itens)
        {                                     // Método de extensão. Adiciona um novo método estático à classe List<T>
            foreach(T item in itens)
            {
                lista.Add(item);
            }
        }
    }
}
