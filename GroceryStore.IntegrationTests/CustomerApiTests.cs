using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GroceryStore.Api;
using GroceryStore.Api.Dtos;
using Xunit;

namespace GroceryStore.IntegrationTests
{
    /// <summary>
    ///     Runs customer api tests.
    /// </summary>
    public class CustomerApiTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        /// <summary>
        ///     Custom application factory to seed in memory db when running integration tests.
        /// </summary>
        private readonly CustomWebApplicationFactory<Startup> _factory;

        /// <summary>
        ///     The mightiest constructor.
        /// </summary>
        /// <param name="factory"></param>
        public CustomerApiTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        /// <summary>
        ///     Tests the get all API.
        /// </summary>
        [Fact]
        public async Task Test1_GetAll()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Customer");
            var customers = JsonSerializer.Deserialize<List<CustomerDto>>(await response.Content.ReadAsStringAsync());

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
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
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Customer/1");
            var customerJson = await response.Content.ReadAsStringAsync();
            var customer = JsonSerializer.Deserialize<CustomerDto>(customerJson,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
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
            var client = _factory.CreateClient();

            // Act
            var data = new StringContent(
                JsonSerializer.Serialize(new CustomerDto {Id = 4, Name = "Turbo Jenkins"}),
                Encoding.UTF8,
                "application/json"
            );
            var response = await client.PostAsync("/Customer", data);
            var customerJson = await response.Content.ReadAsStringAsync();
            var customer = JsonSerializer.Deserialize<CustomerDto>(customerJson,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});


            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
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
            var client = _factory.CreateClient();

            // Act
            var data = new StringContent(
                JsonSerializer.Serialize(new CustomerDto {Id = 2, Name = "Updates McGee"}),
                Encoding.UTF8,
                "application/json"
            );
            var response = await client.PutAsync("/Customer", data);
            var customerJson = await response.Content.ReadAsStringAsync();
            var customer = JsonSerializer.Deserialize<CustomerDto>(customerJson,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(customer);
            Assert.Equal(2, customer.Id);
            Assert.Equal("Updates McGee", customer.Name);
        }
    }
}