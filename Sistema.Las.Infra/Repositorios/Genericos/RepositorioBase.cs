using Microsoft.EntityFrameworkCore;
using Sistema.Las.Domain.Interfaces;
using Sistema.Las.Infra.Contextos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema.Las.Infra.Repositorios
{
    public abstract class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : class, IEntidadeBase
    {
        protected readonly SistemaLasContexto _sistemaLasContexto;
        protected readonly DbSet<TEntidade> _dbSet;

        public RepositorioBase(SistemaLasContexto sistemaLasContexto)
        {
            _sistemaLasContexto = sistemaLasContexto;
            _dbSet = sistemaLasContexto.Set<TEntidade>();
        }

        public async Task AddAsync(TEntidade entity)
        {
            _dbSet.Add(entity);
            await _sistemaLasContexto.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            await _sistemaLasContexto.SaveChangesAsync();
        }

        public void Dispose()
        {
            _sistemaLasContexto?.Dispose();
        }

        public async Task<IEnumerable<TEntidade>> GetAll()
        {
            return await _dbSet
                            .AsNoTracking()
                            .ToListAsync();
        }

        public Task<TEntidade> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TEntidade entity)
        {
            _dbSet.Update (entity);
            await _sistemaLasContexto.SaveChangesAsync();
        }
    }
}
