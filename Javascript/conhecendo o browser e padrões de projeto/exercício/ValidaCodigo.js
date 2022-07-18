class Codigo {
    #codigo;
    constructor(codigo) {
        if (!this.#valida(codigo)) throw new Error('Código inválido.')
        this.#codigo = codigo;
    }

    #valida(codigo) {
        return /^\D{3}-\D{2}-\d{2}$/.test(codigo)
    }

    get codigo() {
        return this.#codigo;
    }
}

let testeSim = new Codigo('ABC-DE-12');
console.log(testeSim.codigo);

let testeNao = new Codigo('123-45-AB');