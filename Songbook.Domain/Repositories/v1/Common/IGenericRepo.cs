using System;
namespace Songbook.Domain.Repositories.v1.Common
{
    public interface IGenericRepo<T> : IRepo where T : class
    {
        Task<bool> AnyByIdAsync(int id);
        Task<bool> AnyByIdAsync(Guid id);
        Task<bool> AnyByIdAsync(string id);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByIdAsync(string id);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}

