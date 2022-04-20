using System.ComponentModel.DataAnnotations;

namespace API_Fase2.Data.DTO.EstoqueDTO
{
    public class ComparaEstoqueDTO
    {

        [Key]
        [Required]
        public int IdEstoque { get; set; }

        [Required]
        public int EstabelecimentoId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public double Valor { get; set; }

    }
}
