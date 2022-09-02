using System.ComponentModel.DataAnnotations;

namespace API_Fase2.Data.DTO.ProdutoListaDTO
{
    public class CreateProdutoListaDTO
    {

        [Required]
        public int ListaId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }

    }
}
