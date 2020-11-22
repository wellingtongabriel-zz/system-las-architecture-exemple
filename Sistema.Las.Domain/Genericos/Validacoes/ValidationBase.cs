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
            var finalResult = new ValidacaoResult();
            foreach (var message in result.Errors)
            {
                finalResult.AddMessage(message.ErrorMessage, Convert(message.Severity));
            }
            return finalResult;
        }

        private static ValidationMessageType Convert(Severity severity)
        {
            switch (severity)
            {
                case Severity.Error:
                    return ValidationMessageType.Error;
                case Severity.Info:
                    return ValidationMessageType.Info;
                default:
                    return ValidationMessageType.Warning;
            }
        }
    }
}
