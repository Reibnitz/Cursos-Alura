class ContaPoupanca extends Conta {
    #saldo;
    
    atualiza(taxa) {
        this.#saldo = this.#saldo + taxa * 2;
    }
}