using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Fase2.Models
{
    public class Lista
    {

        [Key]
        [Required]
        public int IdLista { get; set; }

        [Required(ErrorMessage = "O campo NomeLista é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do campo é 50 caracteres.")]
        public string NomeLista { get; set; }

        [JsonIgnore]
        public virtual List<ProdutoLista> ProdutosLista { get; set; }

    }
}
