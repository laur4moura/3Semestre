using EventPlus_.WebAPI.Models;

namespace EventPlus_.WebAPI.Interface;

public interface ITipoEventoRepository
{
    List<TipoEvento> Listar();
    void Cadastrar (TipoEvento tipoEvento);

    void Atualizar(Guid id, TipoEvento tipoEvento);
    void Deletar(Guid id);

    TipoEvento BuscarPorId(Guid id) ;

}
