using EventPlus_.WebAPI.BdContextEvent;
using EventPlus_.WebAPI.Interfaces;
using EventPlus_.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus_.WebAPI.Repositories;

public class PresencaRepository:IPresencaRepository
{
    private readonly EventContext _context;

    public PresencaRepository(EventContext eventContext)
    {
        _context = eventContext;
    }


    /// <summary>
    /// Endpoint para atualizar uma presença existente, permitindo modificar os detalhes de uma presença específica, como a situação ou o evento associado a ela.
    /// </summary>
    /// <param name="id">Id da presença atualizada</param>
    /// <param name="presenca"></param>
    public void Atualizar(Guid IdPresencaBuscada)
    {
        var presencaBuscada = _context.Presencas.Find(IdPresencaBuscada);

        if (presencaBuscada != null)
        {
            presencaBuscada.Situacao = presencaBuscada.Situacao;

            _context.SaveChanges();
        }
    }

    public void Atualizar(Guid id, Presenca presencaAtualizado)
    {
        throw new NotImplementedException();
    }




    /// <summary>
    /// Busca uma presença por ID, incluindo os detalhes do evento e da instituição associada a esse evento.
    /// </summary>
    /// <param name="id">Id da presença a ser buscada </param>
    /// <returns>presença buscada</returns>
    public Presenca BuscarPorId(Guid id)
    {
        return _context.Presencas
            .Include(p => p.IdEventoNavigation)
            .ThenInclude(e => e!.IdInstituicaoNavigation)
            .FirstOrDefault(p => p.IdPresenca == id)!;
    }


    /// <summary>
    /// Deleta um tipo de presença
    /// </summary>
    /// <param name="id">Id do tipo presença</param>
    public void Deletar(Guid id)
    {
        var presencaBuscada = _context.Presencas.Find(id);
        if (presencaBuscada != null)
        {
            _context.Presencas.Remove(presencaBuscada);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Metodo para inscrever um usuário em um evento, adicionando uma nova presença ao banco de dados.
    /// </summary>
    /// <param name="Inscricao">Presença a ser cadastrado</param>
    public void Inscrever(Presenca Inscricao)
    {
        _context.Presencas.Add(Inscricao);
        _context.SaveChanges();
    }

    public List<Presenca> Listar()
    {
        return _context.Presencas.OrderBy(p => p.IdPresenca).ToList();

    }

    /// <summary>
    /// Lista as presençads de um usuario especifico
    /// </summary>
    /// <param name="IdUsuario">Id do usuário para filtragem </param>
    /// <returns>Uma lista de presenças de um usuario especifico</returns>
    public List<Presenca> ListarMinhas(Guid IdUsuario)
    {
        return  _context.Presencas
            .Include(p => p.IdEventoNavigation)
            .ThenInclude(e => e!.IdInstituicaoNavigation)
            .Where(p => p.IdUsuario == IdUsuario)
            .ToList();
    }
}
