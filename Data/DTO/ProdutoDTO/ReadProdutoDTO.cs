using System.ComponentModel.DataAnnotations;

namespace API_Fase2.Data.DTO.ProdutoDTO
{
    public class ReadProdutoDTO
    {

        [Key]
        [Required]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do campo é 50 caracteres.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo NomeProduto é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do campo é 50 caracteres.")]
        public string NomeProduto { get; set; }

        public DateTime HoraConsulta { get; set; }

    }
}
