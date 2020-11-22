using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistema.Las.Domain.Genericos.Notificacao
{
    public class Notificacao : INotificacao
    {
        private List<Notificador> _notificador;

        public Notificacao()
        {
            _notificador = new List<Notificador>();
        }

        public IEnumerable<Notificador> GetNotifications()
        {
            return _notificador; 
        }

        public void Handle(Notificador message)
        {
            _notificador.Add(message);
        }

        public bool HasNotifications()
        {
            return GetNotifications().Any();
        }
    }
}
