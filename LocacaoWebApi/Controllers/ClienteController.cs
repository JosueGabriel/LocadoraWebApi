using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LocadoraWebApi.Data;
using System.Linq;
using LocadoraWebApi.Models;

namespace LocadoraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _context;

        public ClienteController(DataContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            return Ok(await _context.Clientes.ToListAsync());//.ThenInclude(f => f.Filme).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(i => i.Id == id);
            return cliente == null ? NotFound() : Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        [HttpPut]
        public async Task<ActionResult<Cliente>> PutCliente(Cliente putCliente)
        {
            var cliente = await _context.Clientes.FindAsync(putCliente.Id);
            if (cliente == null)
                return NotFound();

            cliente.Nome = putCliente.Nome;
            cliente.DataNascimento = putCliente.DataNascimento;
            cliente.CPF = putCliente.CPF;

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Cliente>>> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound();

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok(await _context.Clientes.ToListAsync());
        }
        
        [HttpGet] 
        [Route("ClientesComAtraso")]
        public async Task<ActionResult<List<Cliente>>> GetClientesComAtraso() 
        {
            var clientes = await _context.Locacaos
                .Where(x => x.DataDevolucao.CompareTo(x.Filme.Lancamento ? x.DataLocacao.AddDays(2) : x.DataLocacao.AddDays(3)) > 0)
                .Select(x => x.Cliente).Distinct().ToListAsync();
            return clientes == null ? NotFound() : Ok(clientes);
        }
        
        [HttpGet]
        [Route("SegundoClienteMaisAlugou")]
        public async Task<ActionResult<Cliente>> GetSegundoClienteMaisAlugou()
        {
            var clientes = await _context.Clientes
                .OrderByDescending(x => x.Locacaos.Count())
                .ToListAsync();

            return clientes[1] == null ? NotFound() : 
                CreatedAtAction("GetCliente", new { id = clientes[1].Id }, clientes[1]);
        }
    }
}
