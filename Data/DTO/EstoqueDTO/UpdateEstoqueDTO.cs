using API_Fase2.Models;
using System.ComponentModel.DataAnnotations;

namespace API_Fase2.Data.DTO.EstoqueDTO
{
    public class UpdateEstoqueDTO
    {

        public int EstabelecimentoId { get; set; }

        public int ProdutoId { get; set; }

        [Required]
        public double valor { get; set; }

        [Required]
        public int quantidade { get; set; }

    }
}
