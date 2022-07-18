import { View } from "./view.js";

export class MensagemView extends View<string>{
// Determina os tipos genéricos da classe mãe como string

    protected template(modelo: string): string {
        return `
        <p class="alert alert-info">${modelo}</p>
        `;
    }
}