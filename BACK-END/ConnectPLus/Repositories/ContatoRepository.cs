using ConnectPLus.BdContextConnectPlus;
using ConnectPLus.Interface;
using ConnectPLus.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectPLus.Repositories;

public class ContatoRepository : IContatoRepository
{
    private readonly ConnectPlusContext _context;

    public ContatoRepository(ConnectPlusContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza um contato existente, buscando o contato pelo id e atualizando as propriedades com os valores do objeto contato passado como parâmetro.
    /// </summary>
    /// <param name="id">ID do contato a ser atualizado</param>
    /// <param name="contato">Novos dados do contato</param>
    public void Atualizar(Guid id, Contato contato)
    {
        var ContatoBuscado = _context.Contatos.Find(id);

        if (ContatoBuscado != null)
        {
            ContatoBuscado.Nome = contato.Nome;

            ContatoBuscado.Imagem = contato.Imagem;

            ContatoBuscado.FormaContato = contato.FormaContato;

            ContatoBuscado.IdTipoContato = contato.IdTipoContato;

        }

        // o SaveChages() detecta a mudança na propriedade automaticamente

        _context.SaveChanges();
    }

    public void AtualizarIdCorpo(Contato imagemAtualizada)
    {
        throw new NotImplementedException();
    }

    public void AtualizarIdUrl(Guid id, Contato contatoBuscado)
    {
        throw new NotImplementedException();
    }


    /// <summary>
    /// Busca um contato por id 
    /// </summary>
    /// <param name="id">Id do contato a ser buscado</param>
    /// <returns>Objeto contato com as informações do contato buscado</returns>
    public Contato BuscarPorId(Guid id)
    {
        return _context.Contatos.Find(id)!;
    }

    /// <summary>
    /// Cadastra um novo contato
    /// </summary>
    /// <param name="contato">Contato a ser cadastrado</param>
    public void Cadastrar(Contato contato)
    {
        _context.Contatos.Add(contato);
        _context.SaveChanges();
    }


    /// <summary>
    /// Deleta um contato
    /// </summary>
    /// <param name="id">Id do contato</param>
    public void Deletar(Guid id)
    {
        var ContatoBuscado = _context.Contatos.Find(id);

        if (ContatoBuscado != null)
        {
            _context.Contatos.Remove(ContatoBuscado);
            _context.SaveChanges();
        }
    }


    /// <summary>
    /// Busca a lista de contatos cadastrados
    /// </summary>
    /// <returns>Uma lista de contatos</returns>
    public List<Contato> Listar()
    {
        return _context.Contatos.OrderBy(contato => contato).ToList();
    }
}

