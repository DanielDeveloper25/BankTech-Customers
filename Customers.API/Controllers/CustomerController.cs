using Customers.Application.Customers.DTOs;
using Customers.Application.Customers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllDto();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerWithRelatedEntitiesAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet("Email")]
        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            var customer = await _customerService.GetByEmailWithIncludeAsync(email);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<SaveCustomerDTO>> CreateCustomer(SaveCustomerDTO saveCustomerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var createdCustomer = await _customerService.Add(saveCustomerDto);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, UpdateCustomerDTO updateCustomerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            await _customerService.Update(updateCustomerDTO, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.Delete(id);
            return NoContent();
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetAllCustomersPaged([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var customers = await _customerService.GetAllDtoWithPagination(pageNumber, pageSize);
            return Ok(customers);
        }

    }
}
