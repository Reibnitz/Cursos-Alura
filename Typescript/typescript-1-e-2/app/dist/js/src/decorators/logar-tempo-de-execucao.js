export function logarTempoDeExecucao() {
    return function (target, propertyKey, descriptor) {
        const metodoOriginal = descriptor.value;
        descriptor.value = function (...args) {
            const t1 = performance.now();
            const retorno = metodoOriginal.apply(this, args);
            const t2 = performance.now();
            console.log(`Tempo de execução método ${propertyKey}: ${(t2 - t1).toFixed(2)} ms.`);
            return retorno;
        };
        return descriptor;
    };
}
