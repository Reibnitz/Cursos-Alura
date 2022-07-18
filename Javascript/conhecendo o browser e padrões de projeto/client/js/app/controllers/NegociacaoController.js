class NegociacaoController {
    #inputData;
    #inputQuantidade;
    #inputValor;
    #listaNegociacoes;
    #negociacoesView;
    #mensagem;
    #mensagemView;

    constructor() {
        let $ = document.querySelector.bind(document); // Joga o querySeletcor para a variável $. Precisa dar o bind no document para vincular ele ao 'this' do '$' e usar em outros locais.
    
        this.#inputData = $("#data");
        this.#inputQuantidade = $("#quantidade");
        this.#inputValor = $("#valor");
        this.#listaNegociacoes = new ListaNegociacoes();

        this.#negociacoesView = new NegociacoesView($("#negociacoesView"));
        this.#negociacoesView.update(this.#listaNegociacoes);

        this.#mensagem = new Mensagem();
        this.#mensagemView = new MensagemView($('#mensagemView'));
    }

    adiciona(event) {
        event.preventDefault();
        
        const negociacao = this.#criaNegociacao();
        this.#listaNegociacoes.adiciona(negociacao);
        this.#negociacoesView.update(this.#listaNegociacoes);
        
        this.#mensagem.texto = 'Negociação adicionada com sucesso.'
        this.#mensagemView.update(this.#mensagem);

        this.#limpaFormulario();
    }

    #criaNegociacao() {
        return new Negociacao(
            DateHelper.textoParaData(this.#inputData.value),
            this.#inputQuantidade.value,
            this.#inputValor.value
        );
    }

    #limpaFormulario() {
        this.#inputData.value = '';
        this.#inputQuantidade.value = 1;
        this.#inputValor.value = 0.0;

        this.#inputData.focus();
    }
}