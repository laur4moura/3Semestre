using EventPlus_.WebAPI.Models;

namespace EventPlus_.WebAPI.Interface
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
