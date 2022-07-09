using IG.TestStefanini.Business.Interfaces;
using IG.TestStefanini.Business.Models;
using IG.TestStefanini.Business.Models.Validations;

namespace IG.TestStefanini.Business.Services
{
    public class CidadeService : BaseService, ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeService
        (
            ICidadeRepository _cidadeRepository,
            INotificador notificador) : base(notificador)
        {
            this._cidadeRepository = _cidadeRepository;
        }

        public async Task<bool> Adicionar(Cidade cidade)
        {
            if (!ExecutarValidacao(new CidadeValidation(), cidade))
                return false;

            if (_cidadeRepository.Buscar(f => f.Nome == cidade.Nome).Result.Any())
            {
                Notificar("Já existe uma cidade com esse nome.");
                return false;
            }

            await _cidadeRepository.Adicionar(cidade);
            return true;
        }

        public async Task<bool> Atualizar(Cidade cidade)
        {
            if (!ExecutarValidacao(new CidadeValidation(), cidade)) return false;

            if (_cidadeRepository.Buscar(f => f.Nome == cidade.Nome && f.Id != cidade.Id).Result.Any())
            {
                Notificar("Já existe uma cidade com esse nome.");
                return false;
            }

            await _cidadeRepository.Atualizar(cidade);
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _cidadeRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _cidadeRepository?.Dispose();
        }
    }
}
