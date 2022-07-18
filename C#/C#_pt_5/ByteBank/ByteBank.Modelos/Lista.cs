using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    internal class Lista<T>
    {
        private T[] _itens;
        private int _index;
        public int Tamanho
        {
            get
            {
                return this._index;
            }
        }

        public T this[int indice] // indexador, permite fazer chamada como array 'lista[i]'
        {
            get { return this.GetConta(indice); }
        }

        public Lista(int tamanho = 0)
        {
            _itens = new T[tamanho];
            _index = 0;
        }


        public T GetConta(int indice)
        {
            if (indice < 0 || indice >= _index)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return this._itens[indice];
        }

        public void ImprimirLista()
        {
            foreach (T contaCorrente in this._itens)
            {
                if (contaCorrente == null) return;
                Console.WriteLine(contaCorrente);
            }
        }

        public void Adicionar(params T[] contas) // 'params' equivale ao spread operator
        {
            int tamanhoAtual = this._itens.Length;

            T[] novaLista = new T[tamanhoAtual + contas.Length];

            this._itens.CopyTo(novaLista, 0);
            this._itens = novaLista;

            foreach (T conta in contas)
            {
                this._itens[this._index] = conta;
                this._index++;
            }   
        }

        public void Remover(T contaARemover)
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

            this._itens[this._index] = default(T);
        }

        private void DeslocarItens(int indiceInicial)
        {
            for (int i = indiceInicial; i < this._index - 1; i++) // index - 1 e depois usar this._itens[this._index] = null
            {
                this._itens[i] = this._itens[i + 1];
            }
            this._index--;
        }

        private void RecriarLista()
        {
            T[] novaLista = new T[this.Tamanho - 1];
            for (int i = 0; i < this.Tamanho - 1; i++)
            {
                novaLista[i] = this._itens[i];
            }
        }

        private void VerificarCapacidade(int tamanho)
        {
            int tamanhoDaLista = this._itens.Length;

            if (tamanhoDaLista >= tamanho) return;

            T[] novaLista = new T[tamanhoDaLista * 2];
            this._itens.CopyTo(novaLista, 0);

            this._itens = novaLista;
        }
    }
}
