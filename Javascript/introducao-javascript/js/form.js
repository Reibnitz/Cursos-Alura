var botaoAdicionar = document.querySelector("#adicionar-paciente")
botaoAdicionar.addEventListener("click", adicionarPaciente);

function adicionarPaciente(event){

    event.preventDefault();
            
    var form = document.querySelector("#form-adiciona");

    var paciente = obterDadosFormulario(form);
    var verificacao = validarPaciente(paciente);

    if (verificacao.length > 0){
        gerarErros(verificacao);
        return;
    }
    
    adicionaPacienteNaTabela(paciente);

    limparErros();
    form.reset();
}

function adicionaPacienteNaTabela(paciente){
    var pacienteTr = montarTr(paciente);
    var tabela = document.querySelector("#tabela-pacientes");
    tabela.appendChild(pacienteTr);
}

function obterDadosFormulario(form){

    var paciente = { // Cria um objeto 'paciente' com as propriedades listadas.
        nome: form.nome.value, // Usar ':' para atribuir valor à propriedade. Separar com ',' ao final.
        peso: form.peso.value,
        altura: form.altura.value,
        gordura: form.gordura.value,
        imc: calculaImc(form.peso.value,form.altura.value) // Não usar ',' na última propriedade.
    }

    return paciente
}

function montarTr(paciente){
    var pacienteTr = document.createElement("tr");
    pacienteTr.classList.add("paciente");

    var nomeTd = montaTd(paciente.nome,"info-nome")
    var pesoTd = montaTd(paciente.peso,"info-peso")
    var alturaTd = montaTd(paciente.altura,"info-altura");      
    var gorduraTd = montaTd(paciente.gordura,"info-gordura");
    var imcTd = montaTd(paciente.imc,"info-imc");

    pacienteTr.appendChild(nomeTd);
    pacienteTr.appendChild(pesoTd);
    pacienteTr.appendChild(alturaTd);
    pacienteTr.appendChild(gorduraTd);
    pacienteTr.appendChild(imcTd);

    return pacienteTr
}

function montaTd(dado,classe){
    var td = document.createElement("td");
    td.textContent = dado;
    td.classList.add(classe);

    return td;
}

function validarPaciente(paciente) {
    var erros = [];

    if (paciente.nome == "") {
        erros.push("Favor inserir um nome válido")
    }

    if (!validaPeso(paciente.peso)){
        erros.push("Peso inválido")
    }

    if (!validaAltura(paciente.altura)){
        erros.push("Altura inválida")
    }

    if (paciente.gordura <= 0 || paciente.gordura > 100){
        erros.push("Percentual de gordura inválido")
    }
    return erros;
}

function gerarErros(erros) {
    limparErros();
    var listaErros = document.querySelector(".lista-erros");
    
    for (i=0; i < erros.length; i++) {
        var li = document.createElement("li");
        li.textContent = erros[i];
        listaErros.appendChild(li);
    }
}

function limparErros() {
    var listaErros = document.querySelector(".lista-erros");
    listaErros.innerHTML = "";
}