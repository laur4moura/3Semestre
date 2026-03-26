using ConnectPLus.BdContextConnectPlus;
using ConnectPLus.Interface;
using ConnectPLus.Models;

namespace ConnectPLus.Repositories;

public class TipoContatoRepository : ITipoContatoRepository
{
    private readonly ConnectPlusContext _context;

    public TipoContatoRepository(ConnectPlusContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza um tipo de contato usando o rastreamento automático
    /// </summary>
    /// <param name="id">Id do tipo Contato atualizado</param>
    /// <param name="tipoContato">Novos dados do contato</param>
    public void Atualizar(Guid id, TipoContato tipoContato)
    {
        var tipoContatoBuscado = _context.TipoContatos.Find(id);

        if (tipoContatoBuscado != null)
        {
            tipoContatoBuscado.Titulo = tipoContato.Titulo;
        }

        _context.SaveChanges();
    }

    public void Atualizar(TipoContato tipoContato)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Busca um tipo de contato por id usando o rastreamento automático
    /// </summary>
    /// <param name="id">Id do tipo contato buscado</param>
    /// <returns>Objeto tipocontato com as informações do tipo contato buscado</returns>
    public TipoContato BuscarPorId(Guid id)
    {
        return _context.TipoContatos.Find(id)!;
    }

    /// <summary>
    /// Cadastrar um tipo Contato
    /// </summary>
    /// <param name="tipoContato">Tipo Contato a ser Cadastrado</param>
    public void Cadastrar(TipoContato tipoContato)
    {
        _context.TipoContatos.Add(tipoContato);
        _context.SaveChanges();
    }


    /// <summary>
    /// Deleta um tipo de contato
    /// </summary>
    /// <param name="id">Id do tipo contato deletado</param>
    public void Deletar(Guid id)
    {
        var tipoContatoBuscado = _context.TipoContatos.Find(id);
        if (tipoContatoBuscado != null)
        {
            _context.TipoContatos.Remove(tipoContatoBuscado);
            _context.SaveChanges();
        }
    }


    /// <summary>
    /// Busca a lista de tipos de contato ordenada por título usando o rastreamento automático
    /// </summary>
    /// <returns>Uma lista de tipo Contatos</returns>
    public List<TipoContato> Listar()
    {
        return _context.TipoContatos.OrderBy(tipoContato => tipoContato).ToList();
    }
}
