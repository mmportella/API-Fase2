using API_Fase2.Models;
using System.ComponentModel.DataAnnotations;

namespace API_Fase2.Data.DTO.ProdutoListaDTO
{
    public class ReadProdutoListaDTO
    {

        [Key]
        [Required]
        public int IdProdutoLista { get; set; }

        public virtual Produto Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public virtual Lista Lista { get; set; }

        public DateTime HoraConsulta { get; set; }

    }
}
