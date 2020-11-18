using Sistema.Las.Domain.Genericos.Entidades;

namespace Sistema.Las.Domain.Categorias.Comandos
{
    public class CategoriaCommandBase  : CommandBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
