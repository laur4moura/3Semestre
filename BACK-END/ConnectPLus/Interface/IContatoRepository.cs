
using ConnectPLus.Models;

namespace ConnectPLus.Interface;

public interface IContatoRepository
{
    void Cadastrar(Contato contato);

    List<Contato> Listar();

    Contato BuscarPorId(Guid id);

    void Atualizar(Guid id, Contato contato);

    void Deletar(Guid id);
    void AtualizarIdUrl(Guid id, Contato contatoBuscado);
    void AtualizarIdCorpo(Contato imagemAtualizada);
}