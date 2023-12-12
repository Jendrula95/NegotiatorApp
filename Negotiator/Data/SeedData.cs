using Microsoft.EntityFrameworkCore;
using Negotiator.Models;

namespace Negotiator.Data
{
    public class SeedData
    {
        private readonly NegotiatorContext _context;
        public SeedData(NegotiatorContext context)
        {
            _context = context;
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NegotiatorContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<NegotiatorContext>>()))
            {
                // Look for any Product.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }
                context.Product.AddRange(
                    new Products
                    {
                        Name = "Rower",
                        Description = "Rower górski co szybko jeździ",
                        Category = "Sport",
                        BasedPrice = 177.99M,
                    
                    },
                    new Products
                    {
                        Name = "Piłka do nogi",
                        Description = "Piłka do gry",
                        Category = "Sport",
                        BasedPrice = 17.99M,
                   
                    },
                    new Products
                    {
                        Name = "Okulary",
                        Description = "Okulary przeciwsłoneczne",
                        Category = "Akcesoria",
                        BasedPrice = 19.20M,
                  
                    },
                    new Products
                    {
                        Name = "Obraz",
                        Description = "Obraz znanego artysty",
                        Category = "Sztuka",
                        BasedPrice = 477.99M,
                    });
                context.SaveChanges();
                context.Negotiations.AddRange(new Negotiation
                {
                    ProposedPrice = 150.99M,
                    Status = NegotiationStatus.Accepted,
                    Attempts = 2,
                    ProductId = 1,
                    ClientId = 1,
                },
                new Negotiation
                {
                    ProposedPrice = 10.99M,
                    Status = NegotiationStatus.Rejected,
                    Attempts = 0,
                    ProductId = 2,
                    ClientId = 2,
                },
                new Negotiation
                {
                    ProposedPrice = 15.99M,
                    Status = NegotiationStatus.Pending,
                    Attempts = 1,
                    ProductId = 3,
                    ClientId = 1,
                },
                new Negotiation
                {
                    ProposedPrice = 417.99M,
                    Status = NegotiationStatus.Accepted,
                    Attempts = 3,
                    ProductId = 3,
                    ClientId = 2,
                });
                context.SaveChanges();
                context.Client.AddRange(new Client
                {
                    ClientName = "Krzysiek",
                    NegotiationId = 1,
                },
                new Client
                {
                    ClientName = "Staszek",
                    NegotiationId = 2,
                }, new Client
                {
                    ClientName = "Julia",
                    NegotiationId = 3,
                }, new Client
                {
                    ClientName = "Adam",
                    NegotiationId = 4,
                });
                context.SaveChanges();
            }
        }
    }
}