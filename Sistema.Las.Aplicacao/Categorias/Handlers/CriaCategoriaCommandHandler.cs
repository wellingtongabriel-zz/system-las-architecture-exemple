using Sistema.Las.Aplicacao.Categorias.Interfaces;
using Sistema.Las.Aplicacao.Interfaces;
using Sistema.Las.Domain.Categorias.Comandos;
using System.Threading.Tasks;

namespace Sistema.Las.Aplicacao.Categorias.Handlers
{
    public class CriaCategoriaCommandHandler : ICriaCategoriaCommandHandler
    {
        private readonly ICategoriaService _categoriaService;

        public CriaCategoriaCommandHandler(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public async Task<CriaCategoriaCommand> Executa(CriaCategoriaCommand categoriaCommand)
        {
            return await _categoriaService.Adicionar(categoriaCommand);
        }
    }
}
