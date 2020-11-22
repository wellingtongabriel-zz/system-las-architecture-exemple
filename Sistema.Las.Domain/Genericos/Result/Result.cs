using Sistema.Las.Domain.Genericos.Notificacao;
using System.Collections.Generic;

namespace Sistema.Las.Domain.Genericos
{
    public class Result : IResult
    {
        private readonly IList<string> _messages;
        public IEnumerable<string> Messages => _messages;
        public bool Sucesso { get; set; }
        public object Data { get; set; }

        public Result()
        {
            _messages = new List<string>();
        }

        public Result(bool sucesso)
        {
            Sucesso = sucesso;
        }

        public Result(object data)
        {
            Sucesso = true;
            Data = data;
        }

        public void AddMessages(IEnumerable<Notificador> messages)
        {
            foreach (var validationMessage in messages)
            {
                if (!string.IsNullOrEmpty(validationMessage.Mensagem))
                    _messages.Add(validationMessage.Mensagem);
            }
        }
    }
}
