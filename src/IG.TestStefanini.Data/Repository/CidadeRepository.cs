using IG.TestStefanini.Business.Interfaces;
using IG.TestStefanini.Business.Models;
using IG.TestStefanini.Data.Context;

namespace IG.TestStefanini.Data.Repository
{
    public class CidadeRepository : Repository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(TestStefaniniDbContext context) : base(context)
        {
        }
    }
}
