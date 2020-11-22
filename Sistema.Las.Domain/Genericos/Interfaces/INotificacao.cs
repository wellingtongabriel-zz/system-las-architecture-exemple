using System.Collections.Generic;

namespace Sistema.Las.Domain.Genericos.Notificacao
{
    public interface INotificacao
    {
        void Handle(Notificador message);
        IEnumerable<Notificador> GetNotifications();
        bool HasNotifications();
    }
}
