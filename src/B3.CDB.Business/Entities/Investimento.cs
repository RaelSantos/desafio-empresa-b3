namespace B3.CDB.Business.Entities
{
    public class Investimento
    {
        public Investimento(decimal valor, int meses)
        {
            Valor = valor;
            Meses = meses;
        }

        public decimal Valor { get; private set; }
        public int Meses { get; private set; }
    }
}
