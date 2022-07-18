using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ListaContaCorrente
    {
        private ContaCorrente[] _itens;
        private int _index;
        public int Tamanho
        {
            get
            {
                return this._index;
            }
        }

        public ContaCorrente this[int indice] // indexador, permite fazer chamada como array 'lista[i]'
        {
            get { return this.GetConta(indice); }
        }

        public ListaContaCorrente(int tamanho = 5)
        {
            _itens = new ContaCorrente[tamanho];
            _index = 0;
        }


        public ContaCorrente GetConta(int indice)
        {
            if (indice < 0 || indice >= _index)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return this._itens[indice];
        }

        public void ImprimirLista()
        {
            foreach (ContaCorrente contaCorrente in this._itens)
            {
                if (contaCorrente == null) return;
                Console.WriteLine(contaCorrente);
            }
        }

        public void Adicionar(params ContaCorrente[] contas) // 'params' equivale ao spread operator
        {
            this.VerificarCapacidade(_index + contas.Length);
            
            foreach (ContaCorrente conta in contas)
            {
                this._itens[this._index] = conta;
                this._index++;
            }
        }

        public void Remover(ContaCorrente contaARemover)
        {
            for (int i = 0; i < this._index; i++)
            {
                if (this._itens[i].Equals(contaARemover))
                {
                    Console.WriteLine($"Conta {contaARemover} removida.");
                    this.DeslocarItens(i);
                    break;
                }
            }

            this._itens[this._index] = null;
        }

        private void DeslocarItens(int indiceInicial)
        {
            for (int i = indiceInicial; i < this._index - 1; i++) // index - 1 e depois usar this._itens[this._index] = null
            {
                this._itens[i] = this._itens[i + 1];
            }
            this._index--;
        }

        private void VerificarCapacidade(int tamanho)
        {
            int tamanhoDaLista = this._itens.Length;

            if (tamanhoDaLista >= tamanho) return;

            ContaCorrente[] novaLista = new ContaCorrente[tamanhoDaLista * 2];
            this._itens.CopyTo(novaLista, 0);

            this._itens = novaLista;
        }
    }
}
