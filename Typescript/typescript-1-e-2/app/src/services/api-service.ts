import { NegociacoesApi } from "../interfaces/negociacao-api";
import { Negociacao } from "../models/Negociacao.js";


export class ApiService {

    public fetchApi(): Promise<Array<Negociacao>> {
        return (async function(): Promise<Array<Negociacao>> {
            const resposta = await fetch('http://localhost:8080/dados');
            const json = await resposta.json();
            
            const negociacoesApi = json.map((dado: NegociacoesApi) => {
                return new Negociacao(new Date(), dado.vezes, dado.montante);
            });
            
            return negociacoesApi
        })();
    }
}