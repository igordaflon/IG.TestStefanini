using AutoMapper;
using IG.TestStefanini.Api.ViewModels;
using IG.TestStefanini.Business.Interfaces;
using IG.TestStefanini.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace IG.TestStefanini.Api.Controllers
{
    [ApiVersion("1.0")]
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CidadeViewModel>> GetById(int id)
        {
            var cidade = _mapper.Map<CidadeViewModel>(await _cidadeRepository.ObterPorId(id));

            if (cidade == null) return NotFound();

            return cidade;
        }

        [HttpPost]
        public async Task<ActionResult<CidadeViewModel>> Post(CidadeViewModel cidadeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _cidadeService.Adicionar(_mapper.Map<Cidade>(cidadeViewModel));

            return CustomResponse();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CidadeViewModel>> Put(int id, CidadeViewModel cidadeViewModel)
        {
            if (id != cidadeViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(cidadeViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _cidadeService.Atualizar(_mapper.Map<Cidade>(cidadeViewModel));

            return CustomResponse(cidadeViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CidadeViewModel>> Delete(int id)
        {
            var cidadeViewModel = _mapper.Map<CidadeViewModel>(await ObterCidade(id));

            if (cidadeViewModel == null) return NotFound();

            await _cidadeService.Remover(id);

            return CustomResponse(cidadeViewModel);
        }

        private async Task<CidadeViewModel> ObterCidade(int id)
        {
            return _mapper.Map<CidadeViewModel>(await _cidadeRepository.ObterPorId(id));
        }
    }
}
