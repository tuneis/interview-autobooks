using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using GroceryStore.Api.Dtos;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GroceryStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        ///     The customer service.
        /// </summary>
        private readonly ICustomerService _customerService;

        /// <summary>
        ///     The logger.
        /// </summary>
        private readonly ILogger<CustomerController> _logger;

        /// <summary>
        ///     Auto mapper to map models to dtos.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        ///     The almighty constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="customerService"></param>
        /// <param name="mapper"></param>
        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService, IMapper mapper)
        {
            _logger = logger;
            _customerService = customerService;
            _mapper = mapper;
        }

        /// <summary>
        ///     Gets all customers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerDto>), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotFoundResult), (int) HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var customers = await _customerService.GetAllAsync();

                if (customers == null)
                    return NotFound();

                return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customers));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return Problem(
                    e.Message,
                    e.Source,
                    (int) HttpStatusCode.InternalServerError,
                    "Error retrieving customers.",
                    e.GetType().ToString()
                );
            }
        }

        /// <summary>
        ///     Gets a customer by their id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(CustomerDto), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotFoundResult), (int) HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var customer = await _customerService.GetByIdAsync(id);

                if (customer == null)
                    return NotFound();

                return Ok(_mapper.Map<Customer>(customer));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return Problem(
                    e.Message,
                    e.Source,
                    (int) HttpStatusCode.InternalServerError,
                    "Error retrieving customer.",
                    e.GetType().ToString()
                );
            }
        }

        /// <summary>
        ///     Creates a customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), (int) HttpStatusCode.Created)]
        [ProducesResponseType(typeof(NotFoundResult), (int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BadRequestResult), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] CustomerDto customer)
        {
            try
            {
                // check for null
                if (customer == null)
                    return BadRequest("Customer cannot be null.");

                // update
                var created = await _customerService.CreateAsync(_mapper.Map<Customer>(customer));

                // not created will return null
                if (created == null)
                    return NotFound();

                return Created(Request.Path, _mapper.Map<CustomerDto>(created));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return Problem(
                    e.Message,
                    e.Source,
                    (int) HttpStatusCode.InternalServerError,
                    "Error creating customer.",
                    e.GetType().ToString()
                );
            }
        }

        /// <summary>
        ///     Updates a customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(CustomerDto), (int) HttpStatusCode.Created)]
        [ProducesResponseType(typeof(NotFoundResult), (int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BadRequestResult), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomerDto customer)
        {
            try
            {
                // check for null
                if (customer == null)
                    return BadRequest("Customer cannot be null.");

                // update
                var updated = await _customerService.UpdateAsync(_mapper.Map<Customer>(customer));

                // not updated will return null
                if (updated == null)
                    return NotFound();

                return Created(Request.Path, _mapper.Map<CustomerDto>(updated));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return Problem(
                    e.Message,
                    e.Source,
                    (int) HttpStatusCode.InternalServerError,
                    "Error updating customer.",
                    e.GetType().ToString()
                );
            }
        }
    }
}