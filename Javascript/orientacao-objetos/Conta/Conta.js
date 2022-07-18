export class Conta {
    constructor(agencia, cliente, saldoInicial){
        if (this.constructor == Conta) {
            throw new Error("Não é possível instanciar um objeto utilizando a classe Conta.")
        } // Classe abstrata só serve para ser herdada. Esse erro evita que ela seja instanciada diretamente.

        this._agencia = agencia;
        this._cliente = cliente;
        this._saldo = saldoInicial;
    }

    // setters e getters são assessores e não métodos.
    set cliente(novoValor){ // Faz com que o atributo '_cliente' seja acessível por 'cliente'.
        if(novoValor instanceof Cliente){ // 'instanceof' testa se 'novoValor' é uma instância do construtor 'Cliente'.
            this._cliente = novoValor;
        }
    }    

    get cliente() {
        return this._cliente;
    }

    get saldo() {
        return this._saldo;
    }

    sacar(valor) { // Métodos abstratos devem ser sobre escritos pelas classes-filhas.
        throw new Error("O método de saque não foi habilitado para essa categoria de conta.")
    }

    _sacar(valor, taxa) {
        const valorSacado = valor * taxa

        if(this._saldo < valorSacado) return;

        this._saldo -= valorSacado;
        return valorSacado;
    }

    depositar(valor) {
        if(valor <= 0) return;
        this._saldo += valor;
        return valor;
    }

    transferir(conta, valor) {
        if(this.saldo <= valor) return;
        this.sacar(valor);
        conta.depositar(valor);
    }
}