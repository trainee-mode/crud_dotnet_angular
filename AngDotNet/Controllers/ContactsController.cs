using AngDotNet.Data;
using AngDotNet.Models;
using AngDotNet.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AngDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactlyDbContext dbContext;
        public ContactsController(ContactlyDbContext dbContext) {
           
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllContacts() {
            var contacts = dbContext.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(Guid id)
        {
            var contact = dbContext.Contacts.FirstOrDefault(x => x.Id == id);

            if (contact == null)
            {
                return NotFound("Contact not found");
            }

            return Ok(contact);
        }

        [HttpPost]
        public IActionResult AddContact(AddContactRequestDTO request ) {
            var domainModelContact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Favourite = request.Favourite
            };

            dbContext.Contacts.Add(domainModelContact);
            dbContext.SaveChanges();
            return Ok(domainModelContact);


        }

        [HttpDelete]
        public IActionResult DeleteContact(Guid id) { 
            var _del = dbContext.Contacts.FirstOrDefault(x => x.Id == id);
            if (_del != null) {
                dbContext.Contacts.Remove(_del);
                dbContext.SaveChanges();
                
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(Guid id, UpdateContactRequestDTO request)
        {
            var contactToUpdate = dbContext.Contacts.FirstOrDefault(x => x.Id == id);

            if (contactToUpdate == null)
            {
                return NotFound("Contact not found");
            }

            contactToUpdate.Name = request.Name;
            contactToUpdate.Email = request.Email;
            contactToUpdate.PhoneNumber = request.PhoneNumber;
            contactToUpdate.Favourite = request.Favourite;

             dbContext.SaveChanges();

            return Ok(contactToUpdate);
        }


    }
}
