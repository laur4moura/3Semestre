using EventPlus_.WebAPI.Models;

namespace EventPlus_.WebAPI.Interface;

public interface IPresencaRepository
{
    void Inscrever(Presenca Inscricao);

    void Deletar(Guid id);

    List<Presenca> Listar();

    Presenca BuscarPorId(Guid id);

    void Atualizar(Guid id);

    List<Presenca> ListarMinhas(Guid IdUsuario);
}
