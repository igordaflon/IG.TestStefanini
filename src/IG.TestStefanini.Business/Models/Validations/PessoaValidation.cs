using FluentValidation;
using IG.TestStefanini.Business.Models.Validations.Docs;

namespace IG.TestStefanini.Business.Models.Validations
{
    public class PessoaValidation : AbstractValidator<Pessoa>
    {
        public PessoaValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(2, 300)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Cpf.Length).Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo Cpf precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(f => CpfValidacao.Validar(f.Cpf)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");

            RuleFor(f => f.Idade)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
