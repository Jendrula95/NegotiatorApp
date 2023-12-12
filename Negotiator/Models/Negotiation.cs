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
        public decimal ProposedPrice {  get; set; }
        public NegotiationStatus Status { get; set;}
        public int Attempts { get; set; } = 3;

        public int ProductId { get; set; }

        public int ClientId { get; set; }

    }
}
