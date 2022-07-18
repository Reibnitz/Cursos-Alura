export function domInjector(seletor) {
    return function (target, propertyKey) {
        let elemento;
        function getter() {
            if (!elemento) {
                elemento = document.querySelector(seletor);
                console.log(`Buscando elemento ${seletor} no DOM e injetando em ${propertyKey}`);
            }
            return elemento;
        }
        Object.defineProperty(target, propertyKey, { get: getter });
    };
}
