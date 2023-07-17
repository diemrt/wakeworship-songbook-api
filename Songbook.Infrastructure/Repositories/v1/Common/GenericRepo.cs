using System;
using Microsoft.EntityFrameworkCore;
using Songbook.Domain.Repositories.v1.Common;

namespace Songbook.Infrastructure.Repositories.v1.Common
{
    public abstract class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly SongbookContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public GenericRepo(SongbookContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AnyByIdAsync(int id)
        {
            var item = await GetByIdAsync(id);

            return item != null;
        }

        public async virtual Task<bool> AnyByIdAsync(Guid id)
        {
            var item = await GetByIdAsync(id);

            return item != null;
        }

        public async Task<bool> AnyByIdAsync(string id)
        {
            var item = await GetByIdAsync(id);

            return item != null;
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            var item = await _context.Set<T>().AsNoTracking().ToListAsync();

            _context.Entry(item).State = EntityState.Detached;

            return item;
        }

        public async virtual Task<T> GetByIdAsync(int id)
        {
            var item = await _context.Set<T>().FindAsync(id);

            if (item == null) return null;

            _context.Entry(item).State = EntityState.Detached;

            return item;
        }

        public async virtual Task<T> GetByIdAsync(Guid id)
        {
            var item = await _context.Set<T>().FindAsync(id);

            if (item == null) return null;

            _context.Entry(item).State = EntityState.Detached;

            return item;
        }

        public async virtual Task<T> GetByIdAsync(string id)
        {
            var item = await _context.Set<T>().FindAsync(id);

            if (item == null) return null;

            _context.Entry(item).State = EntityState.Detached;

            return item;
        }

        public T Create(T entity)
        {
            return _context.Set<T>().Add(entity).Entity;
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }
    }
}

