using Sistema.Las.Domain.Genericos.Interfaces;
using Sistema.Las.Domain.Genericos.Notificacao;
using Sistema.Las.Domain.Genericos.Validacoes;

namespace Sistema.Las.Domain.Genericos.Entidades
{
    public abstract class CommandHandlerBase
    {
        private readonly INotificacao _notificacao;

        public CommandHandlerBase() { }

        public CommandHandlerBase(INotificacao notificacao)
        {
            _notificacao = notificacao;
        }

        protected ValidacaoResult Validate<T, TValidation>(T command, TValidation validation)  where T : CommandBase where TValidation : IValidation<T>
        {
            var result = validation.Validate(command);
            foreach (var validationMessage in result.Mensagens)
            {
                if (!string.IsNullOrEmpty(validationMessage.Message))
                    _notificacao.Handle(validationMessage.Message);
            }

            return result;
        }

        public Result Return(object value) 
            => new Result(value);

        public Result Return()
        {
            var result = new Result();

            if (_notificacao.HasNotifications())
                result.Sucesso = false;
            
            result.AddMessages(_notificacao.GetNotifications());
            return result;
        }
    }
}
