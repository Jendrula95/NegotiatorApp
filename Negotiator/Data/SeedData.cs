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
                    ProposedPrice = 167.92M,
                    Status = NegotiationStatus.Accepted,
                    Attempts = 2,
                 Products = new Products
                 {
                     Name = "Rower",
                     Description = "Rower górski co szybko jeździ",
                     Category = "Sport",
                     BasedPrice = 177.99M,
                 },
                    Client = new Client
                    {
                        ClientName = "Krzysiek",
                    }
                },
                new Negotiation
                {
                    ProposedPrice = 16.12M,
                    Status = NegotiationStatus.Rejected,
                    Attempts = 1,
                    Products = new Products
                    {
                        Name = "Piłka do nogi",
                        Description = "Piłka do gry",
                        Category = "Sport",
                        BasedPrice = 17.99M,
                    },
                    Client = new Client
                    {
                        ClientName = "Staszek",

                    }
                },
                new Negotiation
                {
                    ProposedPrice = 17.92M,
                    Status = NegotiationStatus.Pending,
                    Attempts = 2,
                    Products = new Products
                    {
                        Name = "Okulary",
                        Description = "Okulary przeciwsłoneczne",
                        Category = "Akcesoria",
                        BasedPrice = 19.20M,
                    },
                    Client = new Client
                    {
                        ClientName = "Julia",
                       
                    }
                },
                new Negotiation
                {
                    ProposedPrice = 167.92M,
                    Status = NegotiationStatus.Rejected,
                    Attempts = 0,
                    Products = new Products
                    {
                        Name = "Obraz",
                        Description = "Obraz znanego artysty",
                        Category = "Sztuka",
                        BasedPrice = 477.99M,
                    },
                    Client = new Client
                    {
                        ClientName = "Adam",
                    }
                });
                context.SaveChanges();

                context.Client.AddRange(new Client
                {
                    ClientName = "Krzysiek",
                },
                new Client
                {
                    ClientName = "Staszek",
              
                }, new Client
                {
                    ClientName = "Julia",
                
                }, new Client
                {
                    ClientName = "Adam",
              
                });
                context.SaveChanges();
            }
        }
    }
}