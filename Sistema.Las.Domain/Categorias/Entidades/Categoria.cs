using Sistema.Las.Domain.Entidades;

namespace Sistema.Las.Domain.Categorias.Entidades
{
    public class Categoria : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
    }
}
