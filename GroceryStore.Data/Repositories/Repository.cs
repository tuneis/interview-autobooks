using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryStore.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Repositories
{
    /// <summary>
    ///     The base repository implementation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        /// <summary>
        ///     The grocery store context.
        /// </summary>
        protected readonly GroceryStoreContext Context;

        /// <summary>
        ///     The almighty constructor.
        /// </summary>
        /// <param name="context"></param>
        protected Repository(GroceryStoreContext context)
        {
            Context = context;
        }

        /// <summary>
        ///     Gets all of an entity.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await Context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to retrieve {nameof(T)} entities: {ex.Message}.");
            }
        }

        /// <summary>
        ///     Adds an entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException($"{nameof(T)} entity must not be null.");

            try
            {
                await Context.AddAsync(entity);
                await Context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(T)} could not be saved: {ex.Message}.");
            }
        }

        /// <summary>
        ///     Updates an entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException($"{nameof(T)} entity must not be null.");

            try
            {
                Context.Update(entity);
                await Context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(T)} entity could not be updated: {ex.Message}.");
            }
        }
    }
}