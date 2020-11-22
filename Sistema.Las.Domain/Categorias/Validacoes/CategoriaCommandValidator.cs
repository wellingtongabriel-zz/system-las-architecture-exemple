using Sistema.Las.Domain.Categorias.Comandos;
using Sistema.Las.Domain.Genericos.Validacoes;

namespace Sistema.Las.Domain.Categorias.Validacoes
{
    public abstract class CategoriaCommandValidator<TCategoriaBasico> : ValidationBase<TCategoriaBasico> where TCategoriaBasico : CategoriaCommandBase
    {
    }
}
