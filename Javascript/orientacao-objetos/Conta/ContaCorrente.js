import { Cliente } from "./Cliente.js";
import { Conta } from "./Conta.js";

export class ContaCorrente extends Conta{
    static numeroDeContas = 0; // Atributos estáticos são referentes à classe em si, não aos objetos que ela cria

    constructor(agencia, cliente){
        super(agencia, cliente, 0);
        ContaCorrente.numeroDeContas ++;
    }

    sacar(valor) { // Esse método está sobreescrevendo o método da classe mãe.
        let taxa = 1.1;
        return super._sacar(valor, taxa);
    }

}