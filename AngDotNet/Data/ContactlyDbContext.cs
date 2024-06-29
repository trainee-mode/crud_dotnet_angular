using AngDotNet.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AngDotNet.Data
{
    public class ContactlyDbContext: DbContext
    {
        public ContactlyDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
