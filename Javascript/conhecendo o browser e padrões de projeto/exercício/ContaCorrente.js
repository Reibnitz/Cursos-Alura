class ContaCorrente extends Conta {
    #saldo;

    atualiza(taxa) {
        this.#saldo = this.#saldo + taxa;
    }
}