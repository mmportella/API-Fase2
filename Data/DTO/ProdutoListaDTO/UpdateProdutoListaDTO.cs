using API_Fase2.Models;
using System.ComponentModel.DataAnnotations;

namespace API_Fase2.Data.DTO.ProdutoListaDTO
{
    public class UpdateProdutoListaDTO
    {

        [Required]
        public int ListaId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }

    }
}
