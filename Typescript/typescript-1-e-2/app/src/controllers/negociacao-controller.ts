import { domInjector } from "../decorators/dom-injector.js";
import { logarTempoDeExecucao } from "../decorators/logar-tempo-de-execucao.js";
import { DiasDaSemana } from "../enums/dias-da-semana.js";
import { Negociacao } from "../models/Negociacao.js";
import { Negociacoes } from "../models/Negociacoes.js";
import { ApiService } from "../services/api-service.js";
import { imprimir } from "../utils/imprimir.js";
import { MensagemView } from "../views/mensagem-view.js";
import { NegociacoesView } from "../views/negociacoes-view.js";

export class NegociacaoController {
    @domInjector('#data')
    private inputData: HTMLInputElement;
    @domInjector('#quantidade')
    private inputQuantidade: HTMLInputElement;
    @domInjector('#valor')
    private inputValor: HTMLInputElement;
    private negociacoes: Negociacoes = new Negociacoes();
    private negociacoesView = new NegociacoesView('negociacoesView');
    private mensagemView = new MensagemView('mensagemView');
    private servicoApi = new ApiService();

    constructor() {
        this.negociacoesView.update(this.negociacoes);
    }

    @logarTempoDeExecucao()
    public adicionar(): void {
        const negociacao = Negociacao.criar(
            this.inputData.value,
            this.inputQuantidade.value,
            this.inputValor.value
        );

        imprimir(negociacao, this.negociacoes);

        if (this.ehDiaUtil(negociacao.data)) {
            this.negociacoes.adicionar(negociacao);
            this.negociacoesView.update(this.negociacoes);
            this.mensagemView.update('Negociação adicionada com sucesso');
            this.limparFormulario();
        } else {
            this.mensagemView.update('Negociações só podem ser criadas em dias úteis')
        }
    }

    public importarDados(): void {
        const self = this;

        (async function(): Promise<void> {
            const negociacoesApi = await self.servicoApi.fetchApi();

            const negociacoesFiltradas = negociacoesApi.filter(elemento =>
                !self.negociacoes.listar().some((negociacao: Negociacao) => negociacao.ehIgual(elemento))
                ) //The some() method checks if any array elements pass a test (provided as a function).
            
            for (let negociacaoApi of negociacoesFiltradas) {
                self.negociacoes.adicionar(negociacaoApi);
            }
            
            self.negociacoesView.update(self.negociacoes);
        })();
    }

    private ehDiaUtil(data: Date) {
        return data.getDay() != DiasDaSemana.DOMINGO && data.getDay() != DiasDaSemana.SABADO;
    }

    private limparFormulario(): void {
        this.inputData.value = '';
        this.inputQuantidade.value = '';
        this.inputValor.value = '';
        this.inputData.focus();
    }
}