using Sistema.Las.Domain.Categorias.Entidades;
using Sistema.Las.Domain.Categorias.Repositorios;
using Sistema.Las.Infra.Contextos;

namespace Sistema.Las.Infra.Repositorios
{
    public class CategoriaRepositorio : RepositorioBase<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(SistemaLasContexto sistemaLasContexto) : base(sistemaLasContexto) { }
    }
}