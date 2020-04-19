using ContactInformationCore.Interface;
using ContactInformationCore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult Get(int? id)
        {
            try
            {
                if(id == null) { return BadRequest(); }

                Contact contact = _IContact.ContactByID(id);

                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody] Contact contactToUpdate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (contactToUpdate == null)
                    {
                        return BadRequest();
                    }

                    Contact contact = _IContact.ContactByID(id);

                    if (contactToUpdate == null)
                    {
                        return NotFound();
                    }

                    _IContact.UpdateContact(contactToUpdate, contact);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // POST: api/Skills
        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (contact == null)
                    {
                        return BadRequest();
                    }

                    _IContact.SaveContact(contact);

                    if (contact.Id > 0)
                        return CreatedAtRoute("Get", new { Id = contact.Id }, contact);
                    else
                        return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            int result = 0;
            try
            {
                if (id == null) { return BadRequest(); }

                Contact contact = _IContact.ContactByID(id);
                if (contact == null)
                {
                    return NotFound();
                }

                result = _IContact.DeleteContact(id);
                if (result == 0)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
