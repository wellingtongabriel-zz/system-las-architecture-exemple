using Sistema.Las.Aplicacao.Categorias.Interfaces;
using Sistema.Las.Aplicacao.Interfaces;
using Sistema.Las.Domain.Categorias.Comandos;
using Sistema.Las.Domain.Genericos;
using Sistema.Las.Domain.Genericos.Entidades;
using Sistema.Las.Domain.Genericos.Interfaces;
using Sistema.Las.Domain.Genericos.Notificacao;
using System.Threading.Tasks;

namespace Sistema.Las.Aplicacao.Categorias.Handlers
{
    public class CriaCategoriaCommandHandler : CommandHandlerBase, ICriaCategoriaCommandHandler
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IValidation<CriaCategoriaCommand> _validator;

        public CriaCategoriaCommandHandler (
            ICategoriaService categoriaService,
            INotificacao notificacao,
            IValidation<CriaCategoriaCommand> validator) : base(notificacao)
        {
            _categoriaService = categoriaService;
            _validator = validator;
        }

        public async Task<Result> Executa(CriaCategoriaCommand categoriaCommand)
        {
            if (Validate(categoriaCommand, _validator).IsValid)
            {
                var response = await _categoriaService.Adicionar(categoriaCommand);
                return Return(response);
            }

            return Return();
        }
    }
}