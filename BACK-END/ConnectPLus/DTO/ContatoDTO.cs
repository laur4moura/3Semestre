using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ConnectPLus.DTO
{
    public class ContatoDTO
    {
        [Required (ErrorMessage = "Obrigatorios")]
        public string Nome { get; set; } = null!;

        public IFormFile? Imagem { get; set; }

        public string FormaContato { get; set; } = null!;

        public Guid? IdTipoContato { get; set; }
    }
}
