using System.ComponentModel.DataAnnotations;

namespace API_Fase2.Data.DTO.ListaDTO
{
    public class UpdateListaDTO
    {

        [Required(ErrorMessage = "O campo NomeLista é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do campo é 50 caracteres.")]
        public string NomeLista { get; set; }

    }
}
