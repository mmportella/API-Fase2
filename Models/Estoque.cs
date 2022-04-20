using System.ComponentModel.DataAnnotations;

namespace API_Fase2.Models
{
    public class Estoque
    {
        [Key]
        [Required]
        public int IdEstoque { get; set; }

        public virtual Estabelecimento Estabelecimento { get; set; }

        public virtual Produto Produto { get; set; }

        [Required]
        public int EstabelecimentoId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public double Valor { get; set; }

        [Required]
        public int Quantidade { get; set; }

    }
}
