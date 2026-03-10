using EventPlus_.WebAPI.Models;

namespace EventPlus_.WebAPI.Interface;

public interface IComentarioEventoRepository
{
    void Cadastrar(ComentarioEvento comentarioEvento);

    void Deletar(Guid id);
    List<ComentarioEvento> Listar(Guid idEvento);

    ComentarioEvento BuscarPorIdUsuario(Guid IdUsuario, Guid IdEvento);

    List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento);
}
