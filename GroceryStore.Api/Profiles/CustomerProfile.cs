using AutoMapper;
using GroceryStore.Api.Dtos;
using GroceryStore.Data.Models;

namespace GroceryStore.Api.Profiles
{
    /// <summary>
    ///     Profile to map the Customer object to the CustomerDto object.
    /// </summary>
    public class CustomerProfile : Profile
    {
        /// <summary>
        ///     The almighty constructor.
        /// </summary>
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}