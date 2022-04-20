using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Fase2.Models
{
    public class Estabelecimento
    {

        [Key]
        [Required]
        public int IdEstabelecimento { get; set; }

        [Required]
        public int Cnpj { get; set; }

        [Required(ErrorMessage = "O campo NomeEstabelecimento é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do campo é 50 caracteres.")]
        public string NomeEstabelecimento { get; set; }

        [Required(ErrorMessage = "O campo Logradouro é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do campo é 50 caracteres.")]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do campo é 50 caracteres.")]
        public string Cidade { get; set; }

        [Required]
        public int Cep { get; set; }

        [JsonIgnore]
        public virtual List<Estoque> Estoques { get; set; }

    }
}
