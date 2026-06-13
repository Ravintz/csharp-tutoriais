using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _04_05_LojaApi.Data;
using _04_05_LojaApi.Models;

namespace _04_05_LojaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteApi>>> Get()
        {
            return await _context.ClientesApi.ToListAsync();
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<ClienteApi>> GetById(int codigo)
        {
            var cliente = await _context.ClientesApi.FindAsync(codigo);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ClienteApi cliente)
        {
            _context.ClientesApi.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);
        }

        [HttpPut("{codigo}")]
        public async Task<ActionResult> Put(int codigo, ClienteApi cliente)
        {
            var clienteBanco = await _context.ClientesApi.FindAsync(codigo);
            if (clienteBanco == null) return NotFound();

            clienteBanco.Nome = cliente.Nome;
            clienteBanco.Email = cliente.Email;
            clienteBanco.Telefone = cliente.Telefone;

            await _context.SaveChangesAsync();
            return Ok(clienteBanco);
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> Delete(int codigo)
        {
            var cliente = await _context.ClientesApi.FindAsync(codigo);
            if (cliente == null) return NotFound();

            _context.ClientesApi.Remove(cliente);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}