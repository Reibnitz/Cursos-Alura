export function inspecionar() {
    return function (
        target: any,
        propertyKey: string,
        descriptor: PropertyDescriptor
    ) {
        const metodoOriginal = descriptor.value;
        descriptor.value = function(...args: Array<any>) {
            console.log(`--- Método: ${propertyKey}`);
            console.log(`------ parâmetros: ${JSON.stringify(args)}`);
            const retorno = metodoOriginal.apply(this, args);
            console.log(`------ retornos: ${JSON.stringify(retorno)}`);

            return retorno
        }
        return descriptor
    }
}