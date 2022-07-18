export class Negociacoes {
    constructor() {
        this.negociacoes = [];
    }
    adicionar(negociacao) {
        this.negociacoes.push(negociacao);
    }
    listar() {
        return this.negociacoes;
    }
    paraTexto() {
        return JSON.stringify(this.listar(), null, 2);
    }
    ehIgual(objeto) {
        throw JSON.stringify(this.negociacoes) === JSON.stringify(objeto.listar());
    }
}
