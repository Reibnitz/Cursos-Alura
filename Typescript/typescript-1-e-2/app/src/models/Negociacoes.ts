import { Modelo } from "../interfaces/modelo.js";
import { Negociacao } from "./Negociacao.js";

export class Negociacoes implements Modelo<Negociacoes>{
    private negociacoes: Negociacao[] = [];
    // Array<Negociacao> == Negociacao[]
    
    public adicionar(negociacao: Negociacao) {
        this.negociacoes.push(negociacao);
    }
    
    // ReadonlyArray<Negociacao> == readonly Negociacao[]
    public listar(): readonly Negociacao[] {
        // return [...this.negociacoes]; Não necessário com ReadonlyArray
        return this.negociacoes;
    }
    
    public paraTexto(): string {
        return JSON.stringify(this.listar(), null, 2);
    }
    
    public ehIgual(objeto: Negociacoes): boolean {
        throw JSON.stringify(this.negociacoes) === JSON.stringify(objeto.listar());
    }
}