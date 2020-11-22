using FluentValidation;
using Sistema.Las.Domain.Categorias.Comandos;

namespace Sistema.Las.Domain.Categorias.Validacoes
{
    public class CriaCategoriaCommandValidator : CategoriaCommandValidator<CriaCategoriaCommand>
    {
        public CriaCategoriaCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Informe um nome valido!");
        }
    }
}
