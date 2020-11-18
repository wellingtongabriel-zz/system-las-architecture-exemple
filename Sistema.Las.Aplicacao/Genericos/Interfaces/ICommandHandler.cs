﻿using Sistema.Las.Domain.Genericos.Entidades;
using System.Threading.Tasks;

namespace Sistema.Las.Aplicacao.Categorias.Interfaces
{
    public interface ICommandHandler<TCommand> where TCommand : CommandBase
    {
        Task<TCommand> Executa(TCommand TEntidade);
    }
}
