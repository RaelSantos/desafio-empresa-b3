using B3.CDB.Business.DTOs;
using B3.CDB.Business.Entities;
using B3.CDB.Business.Intefaces;

namespace B3.CDB.Business.Services
{
    public class InvestimentoService : IInvestimentoService
    {
        private const decimal TB = 1.08m; // é quanto o banco paga sobre o CDI 
        private const decimal CDI = 0.09m;
        private const decimal Porcen = 100m;

        public async Task<InvestimentoDtoResponse> CalcularCDBAsync(Investimento investimento)
        {
            var dto = new InvestimentoDtoResponse();
            dto.ValorBruto = await CalcularValorBrutoAsync(investimento);
            dto.ValorLiquido = await CalcularValorLiquidoAsync(investimento);

            return dto;
        }

        public async Task<decimal> CalcularValorBrutoAsync(Investimento investimento)
        {
            return (investimento.Valor * (1 + (CDI * TB))) * investimento.Meses / Porcen;
        }

        public async Task<decimal> CalcularValorLiquidoAsync(Investimento investimento)
        {
            var porcentagem = await ObterPorcentagemImpostoAsync(investimento.Meses);
            var valorImposto = (porcentagem / 100) * Porcen;
            var valorBruto = await CalcularValorBrutoAsync(investimento);
            var valorLiquido = valorBruto - valorImposto;

            return valorLiquido;
        }

        public async Task<decimal> ObterPorcentagemImpostoAsync(int meses)
        {
            switch (meses)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    return 22.5m;
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                    return 20m;
                case 13:
                case <= 24:
                    return 17.5m;
                default:
                    return 15m;
            }
        }
    }
}
