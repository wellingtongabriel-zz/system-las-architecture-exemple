namespace Sistema.Las.Domain.Genericos
{
    public class Result : IResult
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Data { get; set; }

        public Result()
        {
        }

        public Result(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            mensagem = Mensagem;
        }

        public Result(object data)
        {
            Sucesso = true;
            Data = data;
        }
    }
}
