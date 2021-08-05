using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryStore.Data.Models;

namespace GroceryStore.Data.Interfaces
{
    /// <summary>
    ///     Customer service interface
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        ///     Gets a customer by their id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Customer> GetByIdAsync(int id);

        /// <summary>
        ///     Gets all customers.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Customer>> GetAllAsync();

        /// <summary>
        ///     Creates a customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task<Customer> CreateAsync(Customer customer);

        /// <summary>
        ///     Updates a customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task<Customer> UpdateAsync(Customer customer);
    }
}