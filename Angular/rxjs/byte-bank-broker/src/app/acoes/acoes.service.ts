import { Acao, AcoesAPI } from './modelo/acoes';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, pluck, tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})
export class AcoesService {
    constructor(private http: HttpClient) {}

    getAcoes(valor?: string) {
        const params = valor ? new HttpParams().append('valor', valor) : undefined;
        return this.http
            .get<AcoesAPI>('http://localhost:3000/acoes', { params })
            .pipe( // Habilita operadores de transformação no fluxo de informação obtida
                tap(valor => console.log(valor)), // Não altera o fluxo, é usado para debugar
                pluck('payload'), // Operador 'pluck' retira alguma propriedade de um objeto ('payload')
                map((lista) => lista.sort((a,b) => this.ordenar(a,b))));
    }

    private ordenar(a:Acao, b: Acao) {
        if (a.codigo > b.codigo) {
            return 1;
        } else if (a.codigo < b.codigo) {
            return -1;
        } else {
            return 0;
        }
    }
}
