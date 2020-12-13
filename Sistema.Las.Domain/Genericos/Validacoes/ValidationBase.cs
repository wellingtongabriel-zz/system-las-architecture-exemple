using FluentValidation;
using Sistema.Las.Domain.Genericos.Entidades;
using Sistema.Las.Domain.Genericos.Interfaces;

namespace Sistema.Las.Domain.Genericos.Validacoes
{
    public class ValidationBase<T> : AbstractValidator<T>, IValidation<T> where T : CommandBase
    {
        public ValidacaoResult Validate(T command) => base.Validate(command).GetResult();
    }

    public static class ValidationResultExtensions
    {
        public static ValidacaoResult GetResult(this global::FluentValidation.Results.ValidationResult result)
        {
            var validacaoResult = new ValidacaoResult();
            foreach (var message in result.Errors)
                validacaoResult.AddMessage(message.ErrorMessage);
     
            return validacaoResult;
        }
    }
}
