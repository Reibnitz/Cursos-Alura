export abstract class View<T> {
// <T> denota um tipo genérico a ser definido pela(s) classe(s) filha(s)
// Classes abstratas não podem ser instanciadas

    protected elemento: HTMLElement; // 'protected' mantém semelhante à 'private', porém permite herança.

    constructor(seletor: string) {
        const verificacao = document.getElementById(seletor);

        if (verificacao) {
            this.elemento = verificacao as HTMLInputElement;
        } else {
            throw Error(`O seletor ${seletor} não existe no DOM.`)
        }
    }

    public update(modelo: T) {
        let template = this.template(modelo);
        this.elemento.innerHTML = template;
    }
    
    protected abstract template(modelo: T): string;
    //Métodos abstratos precisam ser definidos pelas classes-filhas
}