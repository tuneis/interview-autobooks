namespace GroceryStore.Api.Dtos
{
    /// <summary>
    ///     Data transfer object for customers.
    /// </summary>
    public class CustomerDto
    {
        /// <summary>
        ///     The id of the customer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The name of the customer.
        /// </summary>
        public string Name { get; set; }
    }
}