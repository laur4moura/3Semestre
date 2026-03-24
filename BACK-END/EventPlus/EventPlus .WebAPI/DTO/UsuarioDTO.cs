using System.ComponentModel.DataAnnotations;

namespace EventPlus_.WebAPI.DTO
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "Os dados são necessários")]
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public Guid? IdTipoUsuario { get; set; }
    }

}
