using System.Threading.Tasks;
using GroceryStore.Data.Models;

namespace GroceryStore.Data.Interfaces
{
    /// <summary>
    ///     Customer data repository.
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        ///     Gets a customer by their id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Customer> GetByIdAsync(int id);
    }
}