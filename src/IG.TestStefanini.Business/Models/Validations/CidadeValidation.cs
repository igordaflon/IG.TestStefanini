using FluentValidation;

namespace IG.TestStefanini.Business.Models.Validations
{
    public class CidadeValidation : AbstractValidator<Cidade>
    {
        public CidadeValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(2, 200)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Uf)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(2)
                .WithMessage("O campo {PropertyName} precisa ter {Length} caracteres");
        }
    }
}
