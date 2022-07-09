using IG.TestStefanini.Business.Interfaces;
using IG.TestStefanini.Business.Models;
using IG.TestStefanini.Business.Models.Validations;

namespace IG.TestStefanini.Business.Services
{
    public class PessoaService : BaseService, IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService
        (
            IPessoaRepository _pessoaRepository,
            INotificador notificador) : base(notificador)
        {
            this._pessoaRepository = _pessoaRepository;
        }

        public async Task<bool> Adicionar(Pessoa pessoa)
        {
            if (!ExecutarValidacao(new PessoaValidation(), pessoa))
                return false;

            if (_pessoaRepository.Buscar(f => f.Cpf == pessoa.Cpf).Result.Any())
            {
                Notificar("Já existe uma pessoa com esse cpf.");
                return false;
            }

            await _pessoaRepository.Adicionar(pessoa);
            return true;
        }

        public async Task<bool> Atualizar(Pessoa pessoa)
        {
            if (!ExecutarValidacao(new PessoaValidation(), pessoa)) return false;

            if (_pessoaRepository.Buscar(f => f.Cpf == pessoa.Cpf && f.Id != pessoa.Id).Result.Any())
            {
                Notificar("Já existe uma pessoa com esse cpf.");
                return false;
            }

            await _pessoaRepository.Atualizar(pessoa);
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _pessoaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _pessoaRepository?.Dispose();
        }
    }
}
