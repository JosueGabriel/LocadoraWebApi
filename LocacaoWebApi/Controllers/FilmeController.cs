using LocacaoWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly DataContext _context;

        public FilmeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Filme>>> Get()
        {
            return Ok(await _context.Filmes.ToListAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Filme>>> Get(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
                return BadRequest("Não encontramos cliente com este Id...");
            return Ok(filme);
        }
        
        [HttpPost]
        public async Task<ActionResult<List<Filme>>> AddFilme(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
            return Ok(await _context.Filmes.ToListAsync());
        }
        
        [HttpPut]
        public async Task<ActionResult<List<Filme>>> UpdateFilme(Filme request)
        {
            var dbFilme = await _context.Filmes.FindAsync(request.Id);
            if (dbFilme == null)
                return BadRequest("Não encontramos cliente com este Id...");

            dbFilme.Titulo = request.Titulo;
            dbFilme.ClassificacaoIndicativa = request.ClassificacaoIndicativa;
            dbFilme.Lancamento = request.Lancamento;

            await _context.SaveChangesAsync();
            return Ok(await _context.Filmes.ToListAsync());
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Filme>>> Delete(int id)
        {
            var dbFilme = await _context.Filmes.FindAsync(id);
            if (dbFilme == null)
                return BadRequest("Não encontramos cliente com este Id...");

            _context.Filmes.Remove(dbFilme);
            await _context.SaveChangesAsync();
            return Ok(await _context.Filmes.ToListAsync());
        }
    }
}
