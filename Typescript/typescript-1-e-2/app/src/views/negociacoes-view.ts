import { escapar } from "../decorators/escapar.js";
import { inspecionar } from "../decorators/inspecionar.js";
import { Negociacoes } from "../models/Negociacoes.js";
import { View } from "./view.js";

export class NegociacoesView extends View<Negociacoes>{
// Determina os tipos genéricos da classe mãe como 'Negociacoes'

    // @inspecionar()
    // @escapar()
    protected template(modelo: Negociacoes): string {
        return `
        <table class="table table-hover table-bordered">
            <thead>
                <tr>
                    <th>DATA</th>
                    <th>QUANTIDADE</th>
                    <th>VALOR</th>
                </tr>
            </thead>
            <tbody>
                ${modelo.listar().map(negociacao => {
                    return `
                    <tr>
                        <td>${negociacao.data.toLocaleDateString()}</td>
                        <td>${negociacao.quantidade}</td>
                        <td>${negociacao.valor}</td>
                    </tr>
                    `
                }).join('')}
            </tbody>
        </table>
        `;
    }
}