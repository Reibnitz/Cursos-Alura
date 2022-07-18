export function escapar() {
    return function(
        target: any,
        propertyKey: string,
        descriptor: PropertyDescriptor
    ) {
        const metodoOriginal = descriptor.value;
        descriptor.value = function(...args: Array<any>) {
            let retorno = metodoOriginal.apply(this, args);
            if (typeof retorno === 'string') {
                // console.log(`@escapar ativo na classe ${this.constructor.name} para o método ${propertyKey}`);
                retorno = retorno.replace(/<script>.*<\/script>/g, '');
            }
            return retorno;
        }
        return descriptor;
    }
}