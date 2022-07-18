class DateHelper {
    constructor(){
        throw new Error('Esta classe não pode ser instanciada.')
    }

    static textoParaData(texto) {
        if(!/\d{4}-\d{2}-\d{2}/.test(texto)) throw new Error('Formato inválido. A data deve estar no formato aaaa-mm-dd');

        return new Date(...texto.split('-').map((item,indice) => indice == 1 ? item -1 : item));
    }

    static dataParaTexto(data) {
        return `${data.getDate()}/${data.getMonth()+1}/${data.getFullYear()}` 
    }
}

// Métodos estáticos podem ser chamados sem instanciar (criar objeto) da classe.