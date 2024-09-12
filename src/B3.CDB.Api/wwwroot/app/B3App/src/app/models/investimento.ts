export interface Investimento {
  meses: number;
  valor: string;
}

export class InvestimentoResponse {
  valorLiquido: string = '0';
  valorBruto: string = '0';
}
