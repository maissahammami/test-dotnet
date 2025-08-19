using data.Context1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Bibliotheque.Models
{
    public class BibliothequeContextFactory : IDesignTimeDbContextFactory<BibliothequeContext>
    {
        public BibliothequeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BibliothequeContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=Bibliotheque;Trusted_Connection=True;");

            return new BibliothequeContext(optionsBuilder.Options);
        }
    }
}
