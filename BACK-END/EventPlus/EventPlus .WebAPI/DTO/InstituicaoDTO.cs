using System.ComponentModel.DataAnnotations;

namespace EventPlus_.WebAPI.DTO;

public class InstituicaoDTO
{
    [Required(ErrorMessage = "Os dados são necessários")]
    public string? NomeFantasia { get; set; }
   
    public string? Endereco { get; set; }
    
    public string? Cnpj { get; set; }
}
