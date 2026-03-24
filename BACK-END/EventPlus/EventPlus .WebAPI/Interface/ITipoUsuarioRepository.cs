using EventPlus_.WebAPI.Models;

namespace EventPlus_.WebAPI.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();

        void Cadastrar(TipoUsuario tipoUsuario);

        void Atualizar(Guid id, TipoUsuario tipoUsuario);
        void Deletar(Guid id);

        TipoUsuario BuscarPorId(Guid id);
    }
}
