using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negotiator.Data;
using Negotiator.Models;

namespace Negotiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegotiationsController : ControllerBase
    {
        private readonly NegotiatorContext _context;

        public NegotiationsController(NegotiatorContext context)
        {
            _context = context;
        }

        // GET: api/Negotiations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Negotiation>>> GetNegotiations()
        {
            var retVal = await _context.Negotiations.ToListAsync();

            foreach (var elem in retVal)
            {
                elem.Client = new Client();
                elem.Client = GetClient(elem.ClientId);
                elem.Products = new Products(GetProduct(elem.ProductsId));
            }
            return await _context.Negotiations.ToListAsync();
        }

        private Products GetProduct(int ProductsId)
        {
            var products = _context.Product.Find(ProductsId) ;

            return products;
        }

        private Client GetClient(int ClientID)
        {
            var client = _context.Client.Find(ClientID);

            return client;
        }


        // GET: api/Negotiations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Negotiation>> GetNegotiation(int id)
        {
            var negotiation = await _context.Negotiations.FindAsync(id);

            if (negotiation == null)
            {
                return NotFound();
            }
           
            negotiation.Products = new Products(GetProduct(negotiation.ProductsId));
            negotiation.Client = new Client();
            negotiation.Client = GetClient(negotiation.ClientId);
            return negotiation;
        }

        // PUT: api/Negotiations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNegotiation(int id, Negotiation negotiation)
        {
            if (id != negotiation.Id)
            {
                return BadRequest();
            }

            _context.Entry(negotiation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NegotiationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Negotiations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Negotiation>> PostNegotiation(Negotiation negotiation)
        {
            _context.Negotiations.Add(negotiation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNegotiation", new { id = negotiation.Id }, negotiation);
        }

        // DELETE: api/Negotiations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNegotiation(int id)
        {
            var negotiation = await _context.Negotiations.FindAsync(id);
            if (negotiation == null)
            {
                return NotFound();
            }

            _context.Negotiations.Remove(negotiation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NegotiationExists(int id)
        {
            return _context.Negotiations.Any(e => e.Id == id);
        }
    }
}
