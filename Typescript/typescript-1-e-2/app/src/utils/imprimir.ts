import { Imprimivel } from "./imprimivel.js";

export function imprimir(...valores: Array<Imprimivel>): void {
    valores.forEach(valor => console.log(valor.paraTexto()));
}