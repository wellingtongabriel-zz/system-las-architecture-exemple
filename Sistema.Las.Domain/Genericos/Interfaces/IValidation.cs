using Sistema.Las.Domain.Genericos.Entidades;
using Sistema.Las.Domain.Genericos.Validacoes;

namespace Sistema.Las.Domain.Genericos.Interfaces
{
    public interface IValidation<in TCommand> where TCommand : CommandBase
    {
        ValidacaoResult Validate(TCommand command);
    }
}
