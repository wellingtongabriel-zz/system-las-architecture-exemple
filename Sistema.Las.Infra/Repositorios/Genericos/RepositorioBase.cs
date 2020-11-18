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

        public async Task<TEntidade> AddAsync(TEntidade entidade)
        {
            _dbSet.Add(entidade);
            await _sistemaLasContexto.SaveChangesAsync();
            return entidade;
        }

        public async Task<TEntidade> UpdateAsync(TEntidade entidade)
        {
            _dbSet.Update(entidade);
            await _sistemaLasContexto.SaveChangesAsync();
            return entidade;
        }

        public async Task DeleteAsync(Guid id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            await _sistemaLasContexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntidade>> GetAllAsync()
        {
            return await _dbSet
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<TEntidade> GetByIdAsync(Guid id)
        {
            return await _dbSet
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Dispose()
        {
            _sistemaLasContexto?.Dispose();
        }
    }
}