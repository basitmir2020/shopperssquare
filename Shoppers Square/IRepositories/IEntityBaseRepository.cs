using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shoppers_Square.IRepositories
{
   public interface IEntityBaseRepository<T> where T: class,IEntityBase,new()
   {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int Id);
        Task<T> GetByIdAsync(int Id, params Expression<Func<T, object>>[] includeProperties);

        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id, T entity);

        bool ExistAsync(string CategorySlug, int Id);


    }
}
