var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { Negociacao } from "../models/Negociacao.js";
export class ApiService {
    fetchApi() {
        return (function () {
            return __awaiter(this, void 0, void 0, function* () {
                const resposta = yield fetch('http://localhost:8080/dados');
                const json = yield resposta.json();
                const negociacoesApi = json.map((dado) => {
                    return new Negociacao(new Date(), dado.vezes, dado.montante);
                });
                return negociacoesApi;
            });
        })();
    }
}
