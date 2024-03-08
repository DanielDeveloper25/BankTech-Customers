using Customers.Application.Contacts.DTOs;
using Customers.Application.Contacts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _contactService.GetAllDto();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var contact = await _contactService.GetByIdDto(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(SaveContactDTO saveContactDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            await _contactService.Add(saveContactDTO);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, UpdateContactDTO updateContactDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            await _contactService.Update(updateContactDTO, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactService.Delete(id);
            return NoContent();
        }
    }
}
