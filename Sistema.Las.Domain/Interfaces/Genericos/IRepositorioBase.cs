using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema.Las.Domain.Interfaces
{
    public interface IRepositorioBase<TEntidade> : IDisposable where TEntidade : class, IEntidadeBase
    {
        Task<IEnumerable<TEntidade>> GetAll();
        Task<TEntidade> GetByIdAsync(Guid id);
        Task AddAsync(TEntidade entity);
        Task UpdateAsync(TEntidade entity);
        Task DeleteAsync(Guid id);
    }
}
