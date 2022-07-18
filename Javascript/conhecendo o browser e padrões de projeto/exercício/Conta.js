class Conta {
    #saldo;
    
    constructor (valor) {
        this.#saldo = valor;
    }

    get saldo() {
        return this.#saldo;
    }

    atualiza(taxa) {
        throw new Error('O método atualiza deve ser implementado.')
    }
}