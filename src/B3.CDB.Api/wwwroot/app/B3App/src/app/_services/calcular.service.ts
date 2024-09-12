import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Investimento, InvestimentoResponse } from '../models/investimento';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CalcularService {
  apiUrl: string = environment.UrlServiceV1;

  constructor(private http: HttpClient) {}

  calcular(investimento: Investimento): Observable<InvestimentoResponse> {
    return this.http
      .post<InvestimentoResponse>(this.apiUrl + 'cdb', investimento)
      .pipe(
        map((response) => {
          return response;
        })
      );
  }
}
