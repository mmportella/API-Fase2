using System.ComponentModel.DataAnnotations;

namespace API_Fase2.Models
{
    public class ProdutoLista
    {
        [Key]
        [Required]
        public int IdProdutoLista { get; set; }

        public virtual Lista Lista { get; set; }

        public virtual Produto Produto { get; set; }

        [Required]
        public int ListaId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }

    }
}
