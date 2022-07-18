export function logarTempoDeExecucao() {
    return function (
        target: any, // origem do método original (não importa)
        propertyKey: string, // nome do método original
        descriptor: PropertyDescriptor // dá acesso a implementação do método decorado através de 'descritor.value'
    ) {
        const metodoOriginal = descriptor.value;
        
        descriptor.value = function(...args: Array<any>) {
            const t1 = performance.now();
            const retorno = metodoOriginal.apply(this, args); // referência de contexto
            // https://www.w3schools.com/js/js_function_apply.asp
            const t2 = performance.now();
            console.log(`Tempo de execução método ${propertyKey}: ${(t2-t1).toFixed(2)} ms.`);
            return retorno
        }
        return descriptor;
    }
}