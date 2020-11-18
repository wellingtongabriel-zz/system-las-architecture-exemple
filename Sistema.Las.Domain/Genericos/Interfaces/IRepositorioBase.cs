using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema.Las.Domain.Interfaces
{
    public interface IRepositorioBase<TEntidade> : IDisposable where TEntidade : class, IEntidadeBase
    {
        Task<IEnumerable<TEntidade>> GetAllAsync();
        Task<TEntidade> GetByIdAsync(Guid id);
        Task<TEntidade> AddAsync(TEntidade entidade);
        Task<TEntidade> UpdateAsync(TEntidade entidade);
        Task DeleteAsync(Guid id);
    }
}
