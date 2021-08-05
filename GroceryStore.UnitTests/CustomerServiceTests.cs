using System.Threading.Tasks;
using GroceryStore.Data.Models;
using Xunit;

namespace GroceryStore.UnitTests
{
    public class UnitTest1
    {
        /// <summary>
        ///     Tests the get all API.
        /// </summary>
        [Fact]
        public async Task Test1_GetAll()
        {
            // Arrange
            var service = new MockCustomerService();

            // Act
            var customers = await service.GetAllAsync();

            // Assert
            Assert.NotNull(customers);
            Assert.NotEmpty(customers);
        }

        /// <summary>
        ///     Tests the retrieve API.
        /// </summary>
        [Fact]
        public async Task Test2_GetById()
        {
            // Arrange
            var service = new MockCustomerService();

            // Act
            var customer = await service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(customer);
            Assert.Equal(1, customer.Id);
            Assert.Equal("Bob", customer.Name);
        }

        /// <summary>
        ///     Tests the create API.
        /// </summary>
        [Fact]
        public async Task Test3_Create()
        {
            // Arrange
            var service = new MockCustomerService();

            // Act
            var customer = await service.CreateAsync(new Customer {Id = 4, Name = "Turbo Jenkins"});

            // Assert
            Assert.NotNull(customer);
            Assert.Equal(4, customer.Id);
            Assert.Equal("Turbo Jenkins", customer.Name);
        }

        /// <summary>
        ///     Tests the update API.
        /// </summary>
        [Fact]
        public async Task Test4_Update()
        {
            // Arrange
            var service = new MockCustomerService();

            // Act
            var customer = await service.UpdateAsync(new Customer {Id = 2, Name = "Aww Yeah"});

            // Assert
            Assert.NotNull(customer);
            Assert.Equal(2, customer.Id);
            Assert.Equal("Aww Yeah", customer.Name);
        }
    }
}