using AutoMapper;
using B3.CDB.Api.DTOs;
using B3.CDB.Business.DTOs;
using B3.CDB.Business.Entities;
using B3.CDB.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace B3.CDB.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/investimentos")]
    public class InvestimentosController : MainController
    {
        private readonly IInvestimentoService _investimentoService;
        private readonly IMapper _mapper;

        public InvestimentosController(INotificador notificador,
            IInvestimentoService investimentoService,
            IMapper mapper) : base(notificador)
        {
            _investimentoService = investimentoService;
            _mapper = mapper;
        }

        [HttpPost("cdb")]
        public async Task<ActionResult<InvestimentoDtoResponse>> Calcular(InvestimentoDtoRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var response = await _investimentoService.CalcularCDBAsync(_mapper.Map<Investimento>(request));

            return CustomResponse(response);
        }
    }
}
