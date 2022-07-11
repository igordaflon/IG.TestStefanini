using AutoMapper;
using IG.TestStefanini.Api.ViewModels;
using IG.TestStefanini.Business.Interfaces;
using IG.TestStefanini.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace IG.TestStefanini.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class PessoaController : MainController
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public PessoaController
        (
            IPessoaRepository _pessoaRepository,
            IPessoaService _pessoaService,
            INotificador notificador,
            IMapper _mapper
        ) : base(notificador)
        {
            this._pessoaRepository = _pessoaRepository;
            this._pessoaService = _pessoaService;
            this._mapper = _mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PessoaViewModel>> GetAll()
        {
            var pessoa = _mapper.Map<IEnumerable<PessoaViewModel>>(await _pessoaRepository.ObterTodos());
            return pessoa;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PessoaViewModel>> GetById(int id)
        {
            var cidade = _mapper.Map<PessoaViewModel>(await _pessoaRepository.ObterPorId(id));

            if (cidade == null) return NotFound();

            return cidade;
        }

        [HttpPost]
        public async Task<ActionResult<PessoaViewModel>> Post(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pessoaService.Adicionar(_mapper.Map<Pessoa>(pessoaViewModel));

            return CustomResponse(pessoaViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PessoaViewModel>> Put(int id, PessoaViewModel pessoaViewModel)
        {
            if (id != pessoaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(pessoaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pessoaService.Atualizar(_mapper.Map<Pessoa>(pessoaViewModel));

            return CustomResponse(pessoaViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PessoaViewModel>> Delete(int id)
        {
            var pessoaViewModel = _mapper.Map<PessoaViewModel>(await ObterPessoa(id));

            if (pessoaViewModel == null) return NotFound();

            await _pessoaService.Remover(id);

            return CustomResponse(pessoaViewModel);
        }

        private async Task<PessoaViewModel> ObterPessoa(int id)
        {
            return _mapper.Map<PessoaViewModel>(await _pessoaRepository.ObterPorId(id));
        }
    }
}
