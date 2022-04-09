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

        public LocacaoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Locacao>>> Get()
        {
            return Ok(await _context.Locacaos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Locacao>>> Get(int id)
        {
            var locacao = await _context.Locacaos.FindAsync(id);
            if (locacao == null)
                return BadRequest("Não encontramos cliente com este Id...");
            return Ok(locacao);
        }

        [HttpPost]
        public async Task<ActionResult<List<Locacao>>> AddLocacao(Locacao locacao)
        {
            _context.Locacaos.Add(locacao);
            await _context.SaveChangesAsync();
            return Ok(await _context.Locacaos.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Locacao>>> UpdateLocacao(Locacao request)
        {
            var dbLocacao = await _context.Locacaos.FindAsync(request.Id);
            if (dbLocacao == null)
                return BadRequest("Não encontramos cliente com este Id...");

            dbLocacao.Id_Cliente = request.Id_Cliente;
            dbLocacao.Id_Filme = request.Id_Filme;
            dbLocacao.DataLocacao = request.DataLocacao; 
            dbLocacao.DataDevolucao = request.DataDevolucao;

            await _context.SaveChangesAsync();
            return Ok(await _context.Locacaos.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Locacao>>> Delete(int id)
        {
            var dbLocacao = await _context.Locacaos.FindAsync(id);
            if (dbLocacao == null)
                return BadRequest("Não encontramos cliente com este Id...");

            _context.Locacaos.Remove(dbLocacao);
            await _context.SaveChangesAsync();
            return Ok(await _context.Locacaos.ToListAsync());
        }
    }
}
