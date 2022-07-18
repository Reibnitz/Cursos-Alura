const form = document.querySelector("#novoItem");
const lista = document.querySelector("#lista");
const itens = JSON.parse(localStorage.getItem("itens")) || []
// Busca local storage. Se não encontrar, retorna um array vazio

itens.forEach(elemento => criaElemento(elemento));
// Arrow function com apenas 1 variável não precisa de parênteses.
// Arrow function não precisa de {}, mas irá retornar o valor resultante (caso seja retornável)

form.addEventListener("submit", (evento) => {
    evento.preventDefault();

    // 'elements' busca os elementos do DOM vinculados ao target e permite selecionar por id/class/name.
    const nome = evento.target.elements["nome"];
    const quantidade = evento.target.elements["quantidade"];

    const existe = itens.find(elemento => elemento.nome === nome.value)
    // Como 'itens' é um array de objetos, a arrow function procura um elemento nesse array cujo valor nome seja igual ao nome.value do form. A função 'find' procura o 1o elemento que satisfaça essa condição e retorna esse objeto, atribuindo-o à variável 'existe'. Caso não encontre, retorna 'undefined', que é considerado falso para condicional if.

    const objItem = {
        "nome" : nome.value,
        "quantidade" : quantidade.value
    }
    
    if (existe) {
        objItem.id = existe.id;
        atualizaElemento(objItem);
        itens[itens.findIndex(elemento => elemento.id === existe.id)] = objItem;
    } else {
        // objItem.id = itens.length;
        if (itens.length > 0) {
            objItem.id = (itens[itens.length-1]).id + 1
        } else {
            objItem.id = 0
        }

        criaElemento(objItem);
        itens.push(objItem);
    }
    
    localStorage.setItem("itens", JSON.stringify(itens));

    nome.value = "";
    quantidade.value = "";
})

function criaElemento(item) {
    const novoItem = document.createElement("li");
    novoItem.classList.add("item");
    
    const qtdItem = document.createElement("strong");
    qtdItem.innerHTML = item.quantidade;
    qtdItem.dataset.id = item.id; // 'dataset' adiciona no HTML um custom-attribute 'data-*' (nesse caso, 'data-id').
    
    novoItem.appendChild(qtdItem);
    novoItem.innerHTML += item.nome;
    novoItem.appendChild(criaBotao(item.id));

    lista.appendChild(novoItem);
}

function criaBotao (id) {
    const botao = document.createElement("button");
    botao.innerHTML = "X";
    botao.addEventListener("click", function() {
        removeElemento(this.parentNode, id);
    })
    return botao;
}

function removeElemento(elemento, id) {
    elemento.remove();

    // Retorna o elemento cujo elemento.id === id. Encontra o index desse elemento e apaga 1 item a partir desse index (apenas ele mesmo)
    itens.splice(itens.findIndex(elemento => elemento.id === id),1);
    localStorage.setItem("itens", JSON.stringify(itens));
}

function atualizaElemento(item) {
    document.querySelector(`[data-id="${item.id}"]`).innerHTML = item.quantidade;
}