using System.Collections.Generic;

namespace Sistema.Las.Domain.Genericos.Notificacao
{
    public interface INotificacao
    {
        void Handle(string mensagem);
        IEnumerable<Notificador> GetNotifications();
        bool HasNotifications();
    }
}
