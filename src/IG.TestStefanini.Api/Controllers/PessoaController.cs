using AutoMapper;
using IG.TestStefanini.Api.ViewModels;
using IG.TestStefanini.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IG.TestStefanini.Api.Controllers
{
    [Route("api/[controller]")]
    public class PessoaController : MainController
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper IMapper;

        public PessoaController
        (
            IPessoaRepository _pessoaRepository,
            INotificador notificador,
            IMapper IMapper
        ) : base(notificador)
        {
            this._pessoaRepository = _pessoaRepository;
            this.IMapper = IMapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PessoaViewModel>> GetAll()
        {
            var pessoa = IMapper.Map<IEnumerable<PessoaViewModel>>(await _pessoaRepository.ObterTodos());
            return pessoa;
        }
     }
}
