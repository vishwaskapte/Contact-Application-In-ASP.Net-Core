using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactInformationCore.Model;
using ContactInformationCore.WebAPI;
using ContactInformationCore.Interface;

namespace ContactInformationCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IContact _IContact;

        public ContactsController(IContact IContact)
        {
            _IContact = IContact;
        }

        // GET: api/Contacts
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Contact> contact = _IContact.GetAllContact();
            return Ok(contact);
        }

        // GET: api/Contacts/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Contact contact = _IContact.ContactByID(id);

            if (contact == null)
            {
                return NotFound("The Skill record couldn't be found.");
            }

            return Ok(contact);
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest("Contact is null.");
            }

            Contact contactToUpdate = _IContact.ContactByID(id);
            if (contactToUpdate == null)
            {
                return NotFound("The Contact record couldn't be found.");
            }

            _IContact.UpdateContact(contactToUpdate);
            return NoContent();
        }

        // POST: api/Skills
        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest("Contact is null.");
            }

            _IContact.SaveContact(contact);
            return CreatedAtRoute(
                  "Get",
                  new { Id = contact.Id },
                  contact);
        }

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Contact contact = _IContact.ContactByID(id);
            if (contact == null)
            {
                return NotFound("The Contact record couldn't be found.");
            }

            _IContact.DeleteContact(id);
            return NoContent();
        }
    }
}
