using B3.CDB.Business.DTOs;
using B3.CDB.Business.Entities;

namespace B3.CDB.Business.Intefaces
{
    public interface IInvestimentoService 
    {
        Task<decimal> CalcularValorLiquidoAsync(Investimento investimento);
        Task<decimal> CalcularValorBrutoAsync(Investimento investimento);
        Task<decimal> ObterPorcentagemImpostoAsync(int meses);
        Task<InvestimentoDtoResponse> CalcularCDBAsync(Investimento investimento);
    }
}
