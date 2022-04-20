using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Fase2.Models
{
    public class Produto
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

        [JsonIgnore]
        public virtual List<Estoque> Estoques { get; set; }

    }
}
