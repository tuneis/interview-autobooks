using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.Models;

namespace GroceryStore.UnitTests
{
    /// <summary>
    ///     Mock repository implementation.
    /// </summary>
    public class MockCustomerRepository : ICustomerRepository
    {
        /// <summary>
        ///     Mock list of customers to simulate the data store.
        /// </summary>
        private readonly List<Customer> _customers = new()
        {
            new Customer {Id = 1, Name = "Bob"},
            new Customer {Id = 2, Name = "Mary"},
            new Customer {Id = 3, Name = "Joe"}
        };

        /// <summary>
        ///     Gets all customers.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await Task.FromResult(_customers);
        }

        /// <summary>
        ///     Creates a customer.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Customer> CreateAsync(Customer entity)
        {
            _customers.Add(entity);
            return await Task.FromResult(entity);
        }

        /// <summary>
        ///     Updates a customer.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Customer> UpdateAsync(Customer entity)
        {
            var customer = _customers.SingleOrDefault(c => c.Id == entity.Id);
            if (customer != null) customer.Name = entity.Name;

            return await Task.FromResult(customer);
        }

        /// <summary>
        ///     Gets a customer by their id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Customer> GetByIdAsync(int id)
        {
            return Task.FromResult(_customers.SingleOrDefault(c => c.Id == id));
        }
    }
}