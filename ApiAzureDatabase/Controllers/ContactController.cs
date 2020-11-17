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
        [Route("api/Contact/")]
        public IActionResult Post([FromBody] Contact value)
        {
            Contact newContact = value;
            contactContext.ContactSet.Add(newContact);
            contactContext.SaveChanges();
            return Ok("Contacto almacenado");
        }

        [HttpPut]
        [Route("api/Contact/{id}")]
        public IActionResult Put(int id, [FromBody] Contact value)
        {
            Contact updatedContact = value;
            var selectedElement = contactContext.ContactSet.Find(updatedContact.Identificador);
            selectedElement.Nombre = value.Nombre;
            selectedElement.Email = value.Email;
            contactContext.SaveChanges();
            return Ok($"dato actualizado {id}");

        }


        [HttpDelete]
        [Route("api/Contact/{id}")]
         public IActionResult Delete(int id)
        {
            var selectedElement = contactContext.ContactSet.Find(id);
            contactContext.ContactSet.Remove(selectedElement);
            contactContext.SaveChanges();
            return Ok($"dato Eliminado {id}");            
        }

        ~ContactController()
        {
            contactContext.Dispose();
        }
    }
}