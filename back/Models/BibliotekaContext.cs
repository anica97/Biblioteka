
using Microsoft.EntityFrameworkCore;

namespace back.Models
{
    public class BibliotekaContext : DbContext
    {
        public DbSet<Knjiga> Knjige { get; set;}
        public DbSet<Biblioteka> Biblioteke { get; set;}
        public DbSet<Red> Redovi { get; set;}


        public BibliotekaContext(DbContextOptions options) : base(options)
        {

        }
    }  

}
