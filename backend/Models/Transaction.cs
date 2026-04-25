namespace ControleFinanceiro.API.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public string Tipo { get; set; } = string.Empty; // ganho ou despesa

        public string Categoria { get; set; } = string.Empty;

        public double Quantidade { get; set; }

        public string Descrição { get; set; } = string.Empty;

        public DateTime Data { get; set; }
    }
}
