using System.Collections.Generic;
using System.Linq;

namespace Sistema.Las.Domain.Genericos.Validacoes
{
    public class ValidacaoResult
    {
        private readonly IList<ValidationMessage> _mensagens;
        public IEnumerable<ValidationMessage> Mensagens => _mensagens;
        public bool IsValid => !Mensagens.Any();

        public ValidacaoResult()
        {
            _mensagens = new List<ValidationMessage>();
        }

        public void AddMessage(string message)
        {
            _mensagens.Add(new ValidationMessage(message));
        }
    }

    public class ValidationMessage
    {
        public string Message { get; private set; }

        private ValidationMessage()
        {
        }

        public ValidationMessage(string message) : this()
        {
            Message = message;
        }
    }
}
