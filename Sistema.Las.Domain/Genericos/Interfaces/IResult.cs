using Sistema.Las.Domain.Genericos.Notificacao;
using System.Collections.Generic;

namespace Sistema.Las.Domain.Genericos
{
    public interface IResult
    {
        void AddMessages(IEnumerable<Notificador> messages);
    }
}
