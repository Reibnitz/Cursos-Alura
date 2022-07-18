paciente = document.querySelectorAll(".paciente") // SelectorAll encontra todos os elementos com essa classe.

for (i=0; i<paciente.length; i++) {
    var pesoPaciente = paciente[i].querySelector(".info-peso").textContent;
    var alturaPaciente = paciente[i].querySelector(".info-altura").textContent;
    var imcPaciente = calculaImc(pesoPaciente,alturaPaciente);

    var pesoValido = validaPeso(pesoPaciente);
    var alturaValida = validaAltura(alturaPaciente);

    if (!pesoValido){ // Sinal '!' identifica 'not'
        pesoValido = false;
        paciente[i].querySelector(".info-imc").textContent = "Peso inválido";
        paciente[i].classList.add("imc-invalido"); // Classe definida no CSS (boa prática).
    }
    
    if (!alturaValida){
        alturaValida = false;
        paciente[i].querySelector(".info-imc").textContent = "Altura inválida";
        paciente[i].classList.add("imc-invalido");
    }
    
    if (pesoValido && alturaValida){
        paciente[i].querySelector(".info-imc").textContent = imcPaciente
    }
}

function calculaImc(peso,altura){
    var imc = 0
    imc = peso / (altura * altura);

    return imc.toFixed(2);
}

function validaPeso(peso){
    if (peso>0 && peso<=1000){
        return true;
    }else{
        return false;
    }
}

function validaAltura(altura){
    if (altura>0 && altura <=3.0){
        return true;
    }else{
        return false;
    }
}