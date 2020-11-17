using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ApiAzureDatabase.Model;

namespace ApiAzureDatabase.Controllers
{
    public class ContactController : Controller
    {
        private ContactContext contactContext;

        public ContactController(ContactContext context)
        {
            contactContext = context;
        }

        [HttpGet]
        [Route("api/Contact")]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            return contactContext.ContactSet.ToList();
        }

        [HttpGet]
        [Route("api/Contact/{id}")]
        public ActionResult<Contact> Get(string id)
        {
            var selected = (from c in contactContext.ContactSet
                           where c.Identificador == id
                           select c).FirstOrDefault();

            return selected;
        }

        [HttpPost]
        //[Route("api/Contact/{id}")]
        public IActionResult Post([FromBody] Contact value)
        {
            Contact newContact = value;
            contactContext.ContactSet.Add(newContact);
            contactContext.SaveChanges();
            return Ok("Contacto almacenado");
        }



        ~ContactController()
        {
            contactContext.Dispose();
        }
    }
}