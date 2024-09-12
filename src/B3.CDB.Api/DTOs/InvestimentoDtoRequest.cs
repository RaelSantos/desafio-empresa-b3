using System.ComponentModel.DataAnnotations;

namespace B3.CDB.Api.DTOs
{
    public class InvestimentoDtoRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]        
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Meses { get; set; }
    }
}
