using ContactBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactBook
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<ContactNote> ContactNotes => Set<ContactNote>();
        public DbSet<ContactTag> ContactTags => Set<ContactTag>();
    }
}
