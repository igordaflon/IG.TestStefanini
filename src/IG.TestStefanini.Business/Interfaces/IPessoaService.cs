using IG.TestStefanini.Business.Models;

namespace IG.TestStefanini.Business.Interfaces
{
    public interface IPessoaService : IDisposable
    {
        Task<bool> Adicionar(Pessoa pessoa);
        Task<bool> Atualizar(Pessoa pessoa);
        Task<bool> Remover(int id);
    }
}
