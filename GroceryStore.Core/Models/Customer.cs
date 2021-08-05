namespace GroceryStore.Data.Models
{
    /// <summary>
    ///     A class representing a custoemr.
    /// </summary>
    public class Customer
    {
        /// <summary>
        ///     The primary key/unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The customers full name.
        /// </summary>
        public string Name { get; set; }
    }
}