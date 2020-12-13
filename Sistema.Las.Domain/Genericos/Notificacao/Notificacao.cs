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
            => _notificador; 

        public void Handle(string mensagem) 
            => _notificador.Add(new Notificador(mensagem));

        public bool HasNotifications() 
            => GetNotifications().Any();
    }
}
