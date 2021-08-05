using System.IO;
using System.Linq;
using GroceryStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace GroceryStore.Data
{
    /// <summary>
    ///     The grocery store context.
    /// </summary>
    public class GroceryStoreContext : DbContext
    {
        /// <summary>
        ///     The almighty constructor.
        /// </summary>
        /// <param name="options"></param>
        public GroceryStoreContext(DbContextOptions<GroceryStoreContext> options) : base(options)
        {
        }

        /// <summary>
        ///     Customer db set.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // parse json for seed data
            var json = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "database.json"));

            // convert to customers list
            var customers = JObject.Parse(json)
                .SelectToken("customers")
                .Select(s => s.ToObject<Customer>())
                .ToList();

            // add seed data
            modelBuilder.Entity<Customer>().HasData(customers);
        }
    }
}