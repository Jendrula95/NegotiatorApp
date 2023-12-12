using Microsoft.EntityFrameworkCore;
using Negotiator.Models;

namespace Negotiator.Data
{
    public class NegotiatorContext : DbContext
    {
        public NegotiatorContext(DbContextOptions<NegotiatorContext> options) : base(options) { }
        public DbSet<Products> Product { get; set; }
        public DbSet<Negotiation> Negotiations { get; set; }
        public DbSet<Client> Client { get; set; }
    }
}
