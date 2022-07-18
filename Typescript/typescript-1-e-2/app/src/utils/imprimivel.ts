export interface Imprimivel {
    paraTexto(): string;
}

// Interfaces são implementadas a partir de 'implements'
// Múltiplas interfaces podem ser implementadas em uma classe, enquanto apenas uma classe-mãe pode ser herdada
// Métodos em interface não precisam ser declarados abstratos
// Métodos abstratos de interfaces precisam ser implementados pelas classes filhas