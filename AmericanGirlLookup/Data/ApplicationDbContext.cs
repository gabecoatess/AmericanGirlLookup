using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AmericanGirlLookup.Models;

namespace AmericanGirlLookup.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AmericanGirlLookup.Models.Doll> Doll { get; set; } = default!;
    }
}
