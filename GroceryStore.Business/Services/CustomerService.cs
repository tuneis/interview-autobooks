using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.Models;

namespace GroceryStore.Data.Services
{
    /// <summary>
    ///     Customer service class.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        /// <summary>
        ///     Customer data repository.
        /// </summary>
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        ///     The almighty constructor.
        /// </summary>
        /// <param name="customerRepository"></param>
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        ///     Gets a customer by their id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        /// <summary>
        ///     Gets all customers.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        /// <summary>
        ///     Creates a customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<Customer> CreateAsync(Customer customer)
        {
            return await _customerRepository.CreateAsync(customer);
        }

        /// <summary>
        ///     Updates a customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<Customer> UpdateAsync(Customer customer)
        {
            return await _customerRepository.UpdateAsync(customer);
        }
    }
}