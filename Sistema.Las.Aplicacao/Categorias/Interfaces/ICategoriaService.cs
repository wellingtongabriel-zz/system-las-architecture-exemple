using Sistema.Las.Aplicacao.Contratos;
using Sistema.Las.Domain.Categorias.Comandos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema.Las.Aplicacao.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaResponse>> BuscarTodos();
        Task<CriaCategoriaCommand> Adicionar(CriaCategoriaCommand criaCategoriaCommand);
    }
}
