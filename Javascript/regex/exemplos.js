//Exemplos práticos:

//1) exec e test:
let alvo = '11a22b33c';
let regex1 = /(\d{2})(\w)/g; // Regex com identificador de grupos

//exec:
console.log(regex1.exec(alvo)); //['11a','11','a', index: 0, input: '11a22b33c', groups: undefined ]

//exec com laço while
let resultado = null;
while(resultado = regex1.exec(alvo)) {
    console.log(resultado)
}
// ['11a','11','a', index: 0, input: '11a22b33c', groups: undefined]
// ['22b','22','b', index: 3, input: '11a22b33c', groups: undefined]
// ['33c','33','c', index: 6, input: '11a22b33c', groups: undefined]

//2) Arquivo CSV com problema de formatação. Deveriam ser números separados por vírgula, porém vieram outros separadores ';' e '-':

const arquivoCsvErro = '100,200-150,200;20';
const regex2 = /[,;-]/;
const novoArquivoCsv = arquivoCsvErro.split(regex2);
console.log(novoArquivoCsv); // ['100','200','150','200','20']

//3) A variável codigos guarda uma string com vários códigos concatenados. A lei de formação é a seguinte: todo código começa com uma letra seguida de 1 ou mais dígitos.

const codigos = 'A121B12112C12212F12G01';
const regex3 = /[A-Za-z]\d+/g;
const codigosExtraidos = codigos.match(regex3);
console.log(codigosExtraidos); // ['A121','B12112','C12212','F12','G01']
