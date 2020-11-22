using System.Collections.Generic;
using System.Linq;

namespace Sistema.Las.Domain.Genericos.Validacoes
{
    public class ValidacaoResult
    {
        private readonly IList<ValidationMessage> _messages;
        public IEnumerable<ValidationMessage> Messages => _messages;
        public bool IsValid => !Messages.Any(x => !x.IsSuccess);

        public ValidacaoResult()
        {
            _messages = new List<ValidationMessage>();
        }

        public void AddMessage(string message, ValidationMessageType type = ValidationMessageType.Error)
        {
            _messages.Add(new ValidationMessage(message, type));
        }
    }

    public class ValidationMessage
    {
        public string Message { get; private set; }
        public ValidationMessageType Type { get; set; }

        private ValidationMessage()
        {
        }

        public ValidationMessage(string message, ValidationMessageType type) : this()
        {
            Message = message;
            Type = type;
        }

        public bool IsSuccess => Type == ValidationMessageType.Success || Type == ValidationMessageType.Info;

    }

    public enum ValidationMessageType
    {
        Success = 1,
        Info = 2,
        Warning = 3,
        Error = 4
    }
}
