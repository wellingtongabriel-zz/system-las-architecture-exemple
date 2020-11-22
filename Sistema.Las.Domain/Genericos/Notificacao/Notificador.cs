namespace Sistema.Las.Domain.Genericos.Notificacao
{
    public class Notificador
    {
        public string Mensagem { get; private set; }

        public Notificador(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}
