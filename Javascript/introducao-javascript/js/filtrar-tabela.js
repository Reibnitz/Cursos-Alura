var filtro = document.querySelector("#filtrar-paciente");

filtro.addEventListener("input", filtrarPacientes);

function filtrarPacientes() {
    var pacientes = document.querySelectorAll(".paciente");
    console.log(this.value);

    if (this.value.length>0){
        for (var i=0; i<pacientes.length; i++){
            var paciente = pacientes[i];
            var nomePaciente = paciente.querySelector(".info-nome").textContent;
            var expressao = new RegExp(this.value, "i"); //The RegExp object is used for matching text with a pattern. 'i'= case insensitive.
                        
            if (!expressao.test(nomePaciente)){ // The test() method executes a search for a match between a regular expression and a specified string.
                paciente.classList.add("invisivel");
            } else {
                paciente.classList.remove("invisivel");
            }            
        }
    } else {
        for (var i=0; i<pacientes.length; i++){
            var paciente = pacientes[i];
            paciente.classList.remove("invisivel");
        }
    }
}