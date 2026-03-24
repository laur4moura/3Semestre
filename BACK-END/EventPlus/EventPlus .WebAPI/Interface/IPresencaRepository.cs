using EventPlus_.WebAPI.Models;

namespace EventPlus_.WebAPI.Interfaces;

public interface IPresencaRepository
{
    void Inscrever(Presenca Inscricao);

    void Deletar(Guid id);

    List<Presenca> Listar();

    Presenca BuscarPorId(Guid id);

    void Atualizar(Guid id, Presenca presencaAtualizado);

    List<Presenca> ListarMinhas(Guid IdUsuario);
}
