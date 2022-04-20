using API_Fase2.Models;
using System.ComponentModel.DataAnnotations;

namespace API_Fase2.Data.DTO.EstoqueDTO
{
    public class ReadEstoqueDTO
    {

        [Key]
        [Required]
        public int IdEstoque { get; set; }

        public virtual Produto Produto { get; set; }

        [Required]
        public double Valor { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public virtual Estabelecimento Estabelecimento { get; set; }

        public DateTime HoraConsulta { get; set; }
    }
}
