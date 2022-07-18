class Negociacao {
    #data;
    #quantidade;
    #valor;

    constructor(data, quantidade, valor) {
        this.#data = new Date(data.getTime());
        this.#quantidade = quantidade;
        this.#valor = valor;
    }

    get volume() {
        return this.#quantidade * this.#valor;
    }

    get data() {
        return new Date(this.#data.getTime());
    }
// Sem essa prática de programação defensiva, a data da negociação poderia ser alterada através de 'exemplo.data.setDate()'
    
    get quantidade() {
        return this.#quantidade
    }

    get valor() {
        return this.#valor
    }
}