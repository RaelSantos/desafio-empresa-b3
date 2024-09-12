using B3.CDB.Business.DTOs;
using B3.CDB.Business.Entities;
using B3.CDB.Business.Intefaces;
using B3.CDB.Business.Services;
using Moq;
using Moq.AutoMock;

namespace B3.CDB.Business.Tests.Services
{
    public class InvestimentoServicesTests
    {
        private readonly AutoMocker _autoMocker;
        private readonly InvestimentoService _investimentoService;
        private readonly Investimento _investimento;
        private readonly InvestimentoDtoResponse _investimentoDtoResponse;

        public InvestimentoServicesTests()
        {
            _autoMocker = new AutoMocker();
            _investimentoService = _autoMocker.CreateInstance<InvestimentoService>();
            _investimento = new Investimento(20000, 1);
            _investimentoDtoResponse = new InvestimentoDtoResponse(196.9400m, 219.4400m);
        }

        [Fact(DisplayName = "Calcular valor bruto retornar valor")]
        [Trait("Categoria", "Investimento")]
        public async void Calcular_Valor_Bruto_Retornar_ValorAsync()
        {
            // Arrange
            var valorBruto = 219.4400m;
            _autoMocker.GetMock<IInvestimentoService>()
                .Setup(i => i.CalcularValorBrutoAsync(_investimento))
                .ReturnsAsync(It.IsAny<decimal>);

            // Act 
            var response = await _investimentoService.CalcularValorBrutoAsync(_investimento);

            // Assert 
            Assert.IsType<decimal>(response);
            Assert.Equivalent(valorBruto, response);
        }

        [Fact(DisplayName = "Calcular valor liquido retornar valor")]
        [Trait("Categoria", "Investimento")]
        public async void Calcular_Valor_Liquido_Retornar_ValorAsync()
        {
            // Arrange
            var valorLiquido = 196.9400m;
            _autoMocker.GetMock<IInvestimentoService>()
                .Setup(i => i.CalcularValorLiquidoAsync(_investimento))
                .ReturnsAsync(It.IsAny<decimal>);

            // Act 
            var response = await _investimentoService.CalcularValorLiquidoAsync(_investimento);

            // Assert 
            Assert.IsType<decimal>(response);
            Assert.Equivalent(valorLiquido, response);
        }

        [Fact(DisplayName = "Obter porcentagem imposto retornar porcentagem")]
        [Trait("Categoria", "Investimento")]
        public async void Obter_Porcentagem_Imposto_Retornar_PorcentagemAsync()
        {
            // Arrange
            var porcentagem = 22.5m;
            _autoMocker.GetMock<IInvestimentoService>()
                .Setup(i => i.ObterPorcentagemImpostoAsync(_investimento.Meses))
                .ReturnsAsync(It.IsAny<decimal>);

            // Act 
            var response = await _investimentoService.ObterPorcentagemImpostoAsync(_investimento.Meses);

            // Assert 
            Assert.IsType<decimal>(response);
            Assert.Equivalent(porcentagem, response);
        }

        [Fact(DisplayName = "Calcular CDB investimento retornar InvestimentoResponse")]
        [Trait("Categoria", "Investimento")]
        public async void Calcular_CDB_Investimento_Retornar_InvestimentoResponseAsync()
        {
            // Arrange            
            _autoMocker.GetMock<IInvestimentoService>()
                .Setup(i => i.CalcularCDBAsync(_investimento))
                .ReturnsAsync(_investimentoDtoResponse);

            // Act 
            var response = await _investimentoService.CalcularCDBAsync(_investimento);

            // Assert 
            Assert.IsType<InvestimentoDtoResponse>(response);
            Assert.Equivalent(_investimentoDtoResponse.ValorLiquido, response.ValorLiquido);
            Assert.Equivalent(_investimentoDtoResponse.ValorBruto, response.ValorBruto);
        }
    }
}
