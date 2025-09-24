using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MRVLeads
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeadsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LeadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("invited")]
        public async Task<ActionResult<List<Lead>>> GetInvitedLeads()
        {
            return await _context.Leads
                .Where(l => l.Status == "New")
                .ToListAsync();
        }

        [HttpGet("accepted")]
        public async Task<ActionResult<List<Lead>>> GetAcceptedLeads()
        {
            return await _context.Leads
                .Where(l => l.Status == "Accepted")
                .ToListAsync();
        }

        [HttpPost("{id}/accept")]
        public async Task<IActionResult> AcceptLead(int id)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead == null)
                return NotFound();

            lead.Status = "Accepted";

            // Aplicar desconto se preço > 500
            if (lead.Price > 500)
            {
                lead.Price = lead.Price * 0.9m; // 10% desconto
            }

            await _context.SaveChangesAsync();

            // Aqui enviaria email para vendas@test.com (fake)
            Console.WriteLine($"Email enviado para vendas@test.com - Lead {id} aceito!");

            return Ok();
        }

        [HttpPost("{id}/decline")]
        public async Task<IActionResult> DeclineLead(int id)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead == null)
                return NotFound();

            lead.Status = "Declined";
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}