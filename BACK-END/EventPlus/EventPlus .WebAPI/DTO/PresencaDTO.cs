using System.ComponentModel.DataAnnotations;

namespace EventPlus_.WebAPI.DTO
{
    public class PresencaDTO
    {
        [Required(ErrorMessage = "Os dados são necessários")]

        public bool Situcao { get; set; }
        public Guid? IdUsuario { get; set; }
        public Guid? IdEvento { get; set; }
    }
}
