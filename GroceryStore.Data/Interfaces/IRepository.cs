using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryStore.Data.Interfaces
{
    /// <summary>
    ///     Generic repository to abstract common CRUD operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class, new()
    {
        /// <summary>
        ///     Gets all of an entity.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        ///     Adds a single entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> CreateAsync(T entity);

        /// <summary>
        ///     Updates a single entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(T entity);
    }
}