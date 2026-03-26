using System.ComponentModel.DataAnnotations;

namespace ConnectPLus.DTO
{
    public class TipoContatoDTO
    {
        [Required(ErrorMessage = "Obrigatórios")]

        public string Titulo { get; set; } = null!;
    }
}
