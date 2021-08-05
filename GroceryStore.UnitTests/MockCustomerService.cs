using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.Models;

namespace GroceryStore.UnitTests
{
    /// <summary>
    ///     Mock the customer service.
    /// </summary>
    public class MockCustomerService : ICustomerService
    {
        /// <summary>
        ///     Mock repository.
        /// </summary>
        private readonly MockCustomerRepository _repository;

        /// <summary>
        ///     Almighty mock constructor.
        /// </summary>
        public MockCustomerService()
        {
            _repository = new MockCustomerRepository();
        }

        /// <summary>
        ///     Gets a customer by their id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        /// <summary>
        ///     Gets all customers.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        /// <summary>
        ///     Creates a customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<Customer> CreateAsync(Customer customer)
        {
            return await _repository.CreateAsync(customer);
        }

        /// <summary>
        ///     Updates a customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<Customer> UpdateAsync(Customer customer)
        {
            return await _repository.UpdateAsync(customer);
        }
    }
}