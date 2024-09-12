using AutoMapper;
using B3.CDB.Api.DTOs;
using B3.CDB.Business.Entities;

namespace B3.CDB.Api.Setup
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<InvestimentoDtoRequest, Investimento>()
             .ConstructUsing(p => new Investimento(p.Valor, p.Meses)).ReverseMap();

            //CreateMap<Investimento, InvestimentoDtoRequest>().ReverseMap();                       
        }
    }
}
