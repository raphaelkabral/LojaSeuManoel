namespace LojaSeuManoel.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public decimal Comprimento { get; set; }

        public List<CaixaEmbala> CaixaEmbala { get; set; } = new();
    }
}
