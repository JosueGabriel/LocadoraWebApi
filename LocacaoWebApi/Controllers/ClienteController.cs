using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LocacaoWebApi.Data;
using LocacaoWebApi.Models;

namespace LocacaoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _context;

        public ClienteController(DataContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return Ok(await _context.Clientes.ToListAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Cliente>>> GetById(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            return cliente == null ? NotFound() : Ok(cliente);
        }
        
        [HttpPost]
        public async Task<ActionResult<List<Cliente>>> AddCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok(await _context.Clientes.ToListAsync());
        }
        
        [HttpPut]
        public async Task<ActionResult<List<Cliente>>> UpdateCliente(Cliente request)
        {
            var dbCliente = await _context.Clientes.FindAsync(request.Id);
            if (dbCliente == null)
                return BadRequest("Não encontramos cliente com este Id...");

            dbCliente.Nome = request.Nome;
            dbCliente.CPF = request.CPF;
            dbCliente.DataNascimento = request.DataNascimento;

            await _context.SaveChangesAsync();
            return Ok(await _context.Clientes.ToListAsync());
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Cliente>>> Delete(int id)
        {
            var dbCliente = await _context.Clientes.FindAsync(id);
            if (dbCliente == null)
                return BadRequest("Não encontramos cliente com este Id...");

            _context.Clientes.Remove(dbCliente);
            await _context.SaveChangesAsync();
            return Ok(await _context.Clientes.ToListAsync());
        }
        
    }
}
