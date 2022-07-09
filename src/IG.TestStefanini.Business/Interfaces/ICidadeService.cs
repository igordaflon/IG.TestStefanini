using IG.TestStefanini.Business.Models;

namespace IG.TestStefanini.Business.Interfaces
{
    public interface ICidadeService : IDisposable
    {
        Task<bool> Adicionar(Cidade cidade);
        Task<bool> Atualizar(Cidade cidade);
        Task<bool> Remover(int id);
    }
}
