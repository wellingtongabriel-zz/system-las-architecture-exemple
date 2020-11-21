using Sistema.Las.Domain.Autenticacao.Comandos;
using Sistema.Las.Domain.Genericos;
using System.Threading.Tasks;

namespace Sistema.Las.Aplicacao.Autenticacao.Interfaces
{
    public interface IAutenticacaoService
    {
        Task<IResult> LogarUsuario(LoginCommand logarCommand);
        Task<IResult> RegistarUsuario(RegistrarUsuarioCommand registrarUsuarioCommand);
    }
}