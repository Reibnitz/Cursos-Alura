// Evento está atrelado à tabela. 
var tabela = document.querySelector("#tabela-pacientes");

tabela.addEventListener("dblclick", removerPaciente);

function removerPaciente(event) {
    var alvoEvento = event.target; // Para fazer com que a função ocorra no elemento clicado, usa-se 'event.target'
    var paiDoAlvo = alvoEvento.parentNode; // Como queremos usar a tr e não td, usa-se 'event.target.parentNode'

    var resposta = confirm("Remover paciente selecionado?");

    if (resposta) {
        paiDoAlvo.classList.add("fade-out");        
        setTimeout(function() {paiDoAlvo.remove();}, 500);
    }
}