using LocacaoWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly DataContext _context;

        public LocacaoController(DataContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locacao>>> GetLocacao()
        {
            return Ok(await _context.Locacaos.Include(c => c.Cliente).Include(f => f.Filme).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Locacao>> GetLocacao(int id)
        {
            var locacao = await _context.Locacaos.Include(c => c.Cliente).Include(f => f.Filme).FirstOrDefaultAsync(i => i.Id == id);
            return locacao == null ? NotFound() : Ok(locacao);
        }

        [HttpPost]
        public async Task<ActionResult<Locacao>> PostLocacao(Locacao locacao)
        {
            _context.Locacaos.Add(locacao);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLocacao", new { id = locacao.Id }, locacao);
        }

        [HttpPut]
        public async Task<ActionResult<Locacao>> PutLocacao(Locacao putLocacao)
        {
            var locacao = await _context.Locacaos.FindAsync(putLocacao.Id);
            if (locacao == null)
                return NotFound();

            locacao.ClienteId = putLocacao.ClienteId;
            locacao.FilmeId = putLocacao.ClienteId;
            locacao.DataLocacao = putLocacao.DataLocacao;
            locacao.DataDevolucao = putLocacao.DataDevolucao;

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLocacao", new { id = locacao.Id }, locacao);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Locacao>>> DeleteLocacao(int id)
        {
            var locacao = await _context.Locacaos.FindAsync(id);
            if (locacao == null)
                return NotFound();

            _context.Locacaos.Remove(locacao);
            await _context.SaveChangesAsync();

            return Ok(await _context.Locacaos.ToListAsync());
        }

    }
}
