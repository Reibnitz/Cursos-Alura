export function domInjector(seletor: string) {
    return function(target: any, propertyKey: string) {

        let elemento: HTMLElement; // Deixando em cache para buscar no DOM apenas na primeira consulta
        function getter() {
            if (!elemento) {
                elemento = document.querySelector(seletor) as HTMLElement;
                console.log(`Buscando elemento ${seletor} no DOM e injetando em ${propertyKey}`);
            }
            return elemento
        }

        // Object.defineProperty(objeto,propriedade,{atributos})
        Object.defineProperty(
            target,
            propertyKey,
            {get: getter}
        );
    }
}