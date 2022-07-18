export class View {
    constructor(seletor, escapar) {
        this.escapar = false;
        const verificacao = document.getElementById(seletor);
        if (verificacao) {
            this.elemento = verificacao;
        }
        else {
            throw Error(`O seletor ${seletor} não existe no DOM.`);
        }
        if (escapar)
            this.escapar = escapar;
    }
    update(modelo) {
        let template = this.template(modelo);
        if (this.escapar) {
            template = template.replace(/<script>.*<\/script>/g, '');
        }
        this.elemento.innerHTML = template;
    }
}
