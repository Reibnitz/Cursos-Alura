// https://www.w3schools.com/js/js_ajax_http.asp

var botaoBuscar = document.querySelector("#buscar-paciente");
botaoBuscar.addEventListener("click", buscarPacientes);

function buscarPacientes() {
    var xhr = new XMLHttpRequest();

    xhr.open("GET", "https://api-pacientes.herokuapp.com/pacientes");
    
    xhr.addEventListener("load", function() {
        var erroAjax = document.querySelector("#erro-ajax");
        
        if (xhr.status == 200) {
            erroAjax.classList.add("invisivel");
            erroAjax.classList.remove("lista-erros");

            var resposta = xhr.responseText;
            var pacientes = JSON.parse(resposta); // JSON = JavaScript Object Notation
            
            pacientes.forEach(function(paciente){
                adicionaPacienteNaTabela(paciente);
            });

        }else{
            console.log(xhr.status);
            erroAjax.classList.remove("invisivel");
            erroAjax.classList.add("lista-erros");
        };
    });

    xhr.send();
};