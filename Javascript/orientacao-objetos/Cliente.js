export class Cliente {
    constructor(nome, cpf, senha) { // 'constructor' define os atributos a serem definidos ao criar um objeto nessa classe.
        this.nome = nome;
        this._cpf = cpf;
        this._senha = senha
    }

    get cpf() {
        return this._cpf;
    }

    get senha() {
        return this._senha;
    }
}