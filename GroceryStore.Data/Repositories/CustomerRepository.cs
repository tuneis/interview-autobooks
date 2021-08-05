using System.Threading.Tasks;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Repositories
{
    /// <summary>
    ///     The customer repository.
    /// </summary>
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        /// <summary>
        ///     The almighty constructor.
        /// </summary>
        /// <param name="context"></param>
        public CustomerRepository(GroceryStoreContext context) : base(context)
        {
        }

        /// <summary>
        ///     Gets a customer by their id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Customer> GetByIdAsync(int id)
        {
            return await Context.Customers.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}