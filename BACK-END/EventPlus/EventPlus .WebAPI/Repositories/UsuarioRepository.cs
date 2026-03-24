using EventPlus_.WebAPI.BdContextEvent;
using EventPlus_.WebAPI.Interfaces;
using EventPlus_.WebAPI.Models;
using EventPlus_.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus_.WebAPI.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly EventContext _context;
    //metódo construtor que aplica a injeção de depedência
    public UsuarioRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Busca o usuário pelo email e valida o hash da senha
    /// </summary>
    /// <param name="Email">Email do usuário a ser buscado</param>
    /// <param name="Senha">Senha para validaro usuário</param>
    /// <returns>Usuário buscado</returns>
    public Usuario BuscarPorEmailESenha(string Email, string Senha)
    {
        var usuarioBuscado = _context.Usuarios
            .Include(usuario => usuario.IdTipoUsuarioNavigation) // 🔥 correção aqui
            .FirstOrDefault(usuario => usuario.Email == Email);

        if (usuarioBuscado != null)
        {
            bool confere = Criptografia.CompararHAsh(Senha, usuarioBuscado.Senha);

            if (confere)
            {
                return usuarioBuscado;
            }
        }

        return null!;
    }


    /// <summary>
    /// Busca um usuário por seu ID, incluindo a navegação para o tipo de usuário associado. Retorna o usuário encontrado ou null se não for encontrado.
    /// </summary>
    /// <param name="id">Íd do usuário a ser buscado</param>
    /// <returns>Usuário a ser buscado e seu tipo de usuário</returns>
    public Usuario BuscarPorId(Guid id)
    {
        return _context.Usuarios.Include(usuario => usuario.IdTipoUsuarioNavigation).FirstOrDefault(usuario => usuario.IdUsuario == id)!;
    }


    /// <summary>
    /// Cadastra um novo usuário, criptografando a senha antes de salvar no banco de dados.E o Id gerado pelo banco
    /// </summary>
    /// <param name="usuario">Usuário a ser cadastrado</param>
    public void Cadastrar(Usuario usuario)
    {
        usuario.Senha = Criptografia.GerarHash(usuario.Senha);
        
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

    }
}