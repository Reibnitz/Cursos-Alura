import { NegociacaoController } from "./src/controllers/negociacao-controller.js"; // '.js' e não ts

const controller = new NegociacaoController();
const form = document.querySelector('.form');

if (form) {
    form.addEventListener('submit', event => {
        event.preventDefault();
        controller.adicionar();
    });
} else {
    throw Error('Não foi possível inicializar a aplicação.')
}

const botaoImportar = document.querySelector('#botao-importar');
if (botaoImportar) {
    botaoImportar.addEventListener('click', () => controller.importarDados());
} else {
    throw Error('Botão de importar não foi encontrado')
}