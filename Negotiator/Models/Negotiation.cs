using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Negotiator.Models
{
    public enum NegotiationStatus
    {
        Accepted,
        Rejected,
       Pending
    }
    public class Negotiation
    {
        public int Id { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Proponowoana cena nie może być niższa niż 0.")]
        public decimal ProposedPrice { get; set; }

        public NegotiationStatus Status { get; set;}
        public int Attempts { get; set; } = 3;
        public int ProductsId { get; set; }
        public virtual Products Products { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
