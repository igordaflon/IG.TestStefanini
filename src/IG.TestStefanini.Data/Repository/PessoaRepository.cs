using IG.TestStefanini.Business.Interfaces;
using IG.TestStefanini.Business.Models;
using IG.TestStefanini.Data.Context;

namespace IG.TestStefanini.Data.Repository
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(TestStefaniniDbContext context) : base(context)
        {
        }
    }
}
