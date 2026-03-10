using EventPlus_.WebAPI.Models;

namespace EventPlus_.WebAPI.Interface;

public interface IEventoRepository
{
    void Cadastrar(Evento evento);

    List<Evento> Listar();

    void Deletar(Guid IdEvento);

    void Atualizar(Guid id, Evento evento);

    List<Evento> ListarPorId(Guid id);

    List<Evento> ProximoEventos();

    Evento BuscarPorId(Guid id);


}
