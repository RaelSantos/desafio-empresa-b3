namespace B3.CDB.Business.DTOs
{
    public class InvestimentoDtoResponse
    {
        public InvestimentoDtoResponse() { }
        public InvestimentoDtoResponse(decimal valorLiquido, decimal valorBruto)
        {
            ValorLiquido = valorLiquido;
            ValorBruto = valorBruto;
        }

        public decimal ValorLiquido { get; set; }
        public decimal ValorBruto { get; set; }        
    }
}
