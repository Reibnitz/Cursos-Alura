export class View {
    constructor(seletor) {
        const verificacao = document.getElementById(seletor);
        if (verificacao) {
            this.elemento = verificacao;
        }
        else {
            throw Error(`O seletor ${seletor} não existe no DOM.`);
        }
    }
    update(modelo) {
        let template = this.template(modelo);
        this.elemento.innerHTML = template;
    }
}
