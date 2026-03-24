namespace EventPlus_.WebAPI.DTO;

public class ComentarioEventoDTO
{
    public string Descricao { get; set; }
    public Guid IdUsuario { get; set; }
    public Guid IdEvento { get; set; }
}
