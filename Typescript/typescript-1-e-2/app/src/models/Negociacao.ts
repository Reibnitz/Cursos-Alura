import { Modelo } from "../interfaces/modelo.js";


export class Negociacao implements Modelo<Negociacao>{
    // Em TS podemos declarar os parâmetros direto no construtor. Necessário explicitar private/public. 'readonly' faz com que esses valores não possam ser alterados, porém possam ser acessados sem a necessidade de criar getters.
    constructor (
        private _data: Date,
        public readonly quantidade: number,
        public readonly valor: number
    ) {}
    
    get data(): Date {
        return new Date(this._data.getTime());
    }

    get volume(): number {
        return this.quantidade * this.valor;
    }

    public static criar(dataString: string, quantidadeString: string, valorString: string) {
        const data = new Date(dataString.replace(/-/g, ','));
        const quantidade = parseInt(quantidadeString);
        const valor = parseFloat(valorString)

        return new Negociacao(data, quantidade, valor);
    }

    public paraTexto(): string {
        return `
        Data: ${this.data}
        Quantidade: ${this.quantidade}
        Valor:  ${this.valor}
        `;
    }

    public ehIgual(negociacao: Negociacao): boolean {
        return this.data.getDate() === negociacao.data.getDate()
            && this.data.getMonth() === negociacao.data.getMonth()
            && this.data.getFullYear() === negociacao.data.getFullYear();
    }
}