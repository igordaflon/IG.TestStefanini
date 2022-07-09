using AutoMapper;
using IG.TestStefanini.Api.ViewModels;
using IG.TestStefanini.Business.Interfaces;
using IG.TestStefanini.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace IG.TestStefanini.Api.Controllers
{
    [Route("api/[controller]")]
    public class CidadeController : MainController
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly ICidadeService _cidadeService;
        private readonly IMapper _mapper;

        public CidadeController
        (
            ICidadeRepository _cidadeRepository,
            ICidadeService _cidadeService,
            IMapper _mapper,
            INotificador notificador
        ) : base(notificador)
        {
            this._cidadeService = _cidadeService;
            this._cidadeRepository = _cidadeRepository;
            this._mapper = _mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CidadeViewModel>> GetAll()
        {
            var cidade = _mapper.Map<IEnumerable<CidadeViewModel>>(await _cidadeRepository.ObterTodos());
            return cidade;
        }

        [HttpPost]
        public async Task<ActionResult<CidadeViewModel>> Post(CidadeViewModel cidadeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _cidadeService.Adicionar(_mapper.Map<Cidade>(cidadeViewModel));

            return CustomResponse(cidadeViewModel);
        }
    }
}
