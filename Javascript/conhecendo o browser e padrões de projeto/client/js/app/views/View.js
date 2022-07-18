class View {
    #elemento;

    constructor(elemento) {
        this.#elemento = elemento;
    }

    template () {
        throw new Error ('O método template deve ser implementado;')
    }

    update(modelo) {
        this.#elemento.innerHTML = this.template(modelo);
    }
}