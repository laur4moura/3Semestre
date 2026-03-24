using EventPlus_.WebAPI.Models;

namespace EventPlus_.WebAPI.Interfaces
{
    public interface IInstituicaoRepository
    {
        List<Instituicao> Listar();

        void Cadastrar (Instituicao instuicao);

        void Atualizar(Guid id, Instituicao instituicao);
        void Deletar(Guid id);
        Instituicao BuscarPorId(Guid id);
    }
}
