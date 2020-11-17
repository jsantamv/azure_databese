using Microsoft.EntityFrameworkCore;

namespace ApiAzureDatabase.Model
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Contact> ContactSet { get; set; }

    }
}