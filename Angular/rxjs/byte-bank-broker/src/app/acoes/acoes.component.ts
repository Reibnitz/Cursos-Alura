import { merge, Subscription } from 'rxjs';
import { AcoesService } from './acoes.service';
import { Acoes } from './modelo/acoes';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged, filter, switchMap, tap } from 'rxjs/operators';

const ESPERA_DIGITACAO = 300;

@Component({
    selector: 'app-acoes',
    templateUrl: './acoes.component.html',
    styleUrls: ['./acoes.component.css'],
})
export class AcoesComponent /* implements OnInit, OnDestroy */ {
    public acoesInput = new FormControl();

    todasAcoes$ = this.acoesService.getAcoes();
    filtroInput$ = this.acoesInput.valueChanges.pipe(
        debounceTime(ESPERA_DIGITACAO), // Espera um tempo determinado para realizar a requisição
        filter(valorDigitado => valorDigitado.length >= 3),
        distinctUntilChanged(), // Evita requisições repetidas
        switchMap((valorDigitado) => this.acoesService.getAcoes(valorDigitado))
    ); // https://rxjs.dev/api/operators/switchMap

    acoes$ = merge(this.todasAcoes$, this.filtroInput$);

    constructor(private acoesService: AcoesService) {}
}
