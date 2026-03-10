using EventPlus_.WebAPI.Models;

namespace EventPlus_.WebAPI.Interface;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario usuario);
    Usuario BuscarPorId(Guid id);
    Usuario BuscarPorEmailESenha(string Email, string Senha);
}
