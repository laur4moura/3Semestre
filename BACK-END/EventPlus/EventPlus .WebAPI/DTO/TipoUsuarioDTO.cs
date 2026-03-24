using System.ComponentModel.DataAnnotations;

namespace EventPlus_.WebAPI.DTO
{
    public class TipoUsuarioDTO
    {
       [Required(ErrorMessage = "O titulo do tipo de Usuário é obrigatório!")]
        public string? Titulo { get; set; }
       

    }
}
