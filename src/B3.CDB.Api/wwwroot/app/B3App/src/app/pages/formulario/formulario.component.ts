import { Component, OnInit } from '@angular/core';
import { CalcularService } from '../../_services/calcular.service';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Investimento, InvestimentoResponse } from '../../models/investimento';
import { CurrencyMaskModule } from 'ng2-currency-mask';
import { CommonModule, registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
registerLocaleData(localePt);

@Component({
  selector: 'app-formulario',
  standalone: true,
  imports: [ReactiveFormsModule, CurrencyMaskModule, CommonModule],
  templateUrl: './formulario.component.html',
  styleUrl: './formulario.component.css',
})
export class FormularioComponent implements OnInit {
  form: FormGroup = new FormGroup({});
  resultado!: string;
  investimento!: Investimento;
  erro: boolean = false;
  response: InvestimentoResponse = new InvestimentoResponse();

  constructor(private fb: FormBuilder, private service: CalcularService) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.form = this.fb.group({
      valor: ['', [Validators.required]],
      meses: ['', [Validators.required]],
    });
  }

  calcular() {
    if (this.form.dirty && this.form.valid) {
      this.investimento = Object.assign({}, this.investimento, this.form.value);

      this.service.calcular(this.investimento).subscribe({
        next: (sucesso: any) => {
          // this.resultado = sucesso.data;
          this.response = sucesso.data;
        },
        error: (falha: any) => {
          this.erro = true;
        },
      });
    }
  }
}
