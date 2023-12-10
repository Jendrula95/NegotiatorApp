using Microsoft.EntityFrameworkCore;

namespace Negotiator.Models
{
    public class NegotiatorContext : DbContext
    {
        public NegotiatorContext(DbContextOptions<NegotiatorContext> options) : base (options) { }
        public DbSet<Products> Product { get; set; } = null!;
    }
}
