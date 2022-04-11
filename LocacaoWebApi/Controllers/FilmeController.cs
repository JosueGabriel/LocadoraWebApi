using LocadoraWebApi.Data;
using LocadoraWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace LocadoraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly DataContext _context;

        public FilmeController(DataContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> GetFilme()
        {
            return Ok(await _context.Filmes.Include(l => l.Locacaos).ThenInclude(c => c.Cliente).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> GetFilme(int id)
        {
            var filme = await _context.Filmes.Include(l => l.Locacaos).ThenInclude(c => c.Cliente).FirstOrDefaultAsync(i => i.Id == id);
            return filme == null ? NotFound() : Ok(filme);
        }

        [HttpPost]
        public async Task<ActionResult<Filme>> PostFilme(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFilme", new { id = filme.Id }, filme);
        }

        [HttpPut]
        public async Task<ActionResult<Filme>> PutFilme(Filme putFilme)
        {
            var filme = await _context.Filmes.FindAsync(putFilme.Id);
            if (filme == null)
                return NotFound();

            filme.Titulo = putFilme.Titulo;
            filme.ClassificacaoIndicativa = putFilme.ClassificacaoIndicativa;
            filme.Lancamento = putFilme.Lancamento;

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFilme", new { id = filme.Id }, filme);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Filme>>> DeleteFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
                return NotFound();

            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();

            return Ok(await _context.Filmes.ToListAsync());
        }


        [HttpGet]
        [Route("FilmesNuncaAlugados")]
        public async Task<ActionResult<List<Filme>>> GetFilmesNuncaAlugados() 
        { 
            var filmes = await _context.Filmes.Where(x => x.Locacaos == null).ToListAsync();
            return filmes == null ? NotFound() : Ok(filmes);
        }

        [HttpGet]
        [Route("Top5Filmes")]
        public async Task<ActionResult<List<Filme>>> GetTop5Filmes()
        {
            var ultimoAno = DateTime.Now.AddYears(-1);
            var filmes = await _context.Filmes.Include(l => l.Locacaos).OrderBy(x => x.Locacaos.Count)
                .Select(x => x.Locacaos.Where(x => x.DataLocacao.Year.CompareTo(ultimoAno.Year) == 0))
                .Take(5).ToListAsync();

            return filmes == null ? NotFound() : Ok(filmes);
        }

        [HttpGet]
        [Route("Top3FilmesMenos")]
        public async Task<ActionResult<List<Filme>>> GetTop3FilmesMenos()
        {
            var ultimoSemana = DateTime.Now.AddDays(-7);
            var filmes = await _context.Filmes.Include(l => l.Locacaos).OrderByDescending(x => x.Locacaos.Count)
                .Select(x => x.Locacaos.Where(x => GetWeekInMonth(x.DataLocacao) == GetWeekInMonth(ultimoSemana)))
                .Take(3).ToListAsync();

            return filmes == null ? NotFound() : Ok(filmes);
        }

        public static int GetWeekInMonth(DateTime date)
        {
            DateTime tempdate = date.AddDays(-date.Day + 1);
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNumStart = ciCurr.Calendar.GetWeekOfYear(tempdate, CalendarWeekRule.FirstFourDayWeek, ciCurr.DateTimeFormat.FirstDayOfWeek);
            int weekNum = ciCurr.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, ciCurr.DateTimeFormat.FirstDayOfWeek);
            return weekNum - weekNumStart + 1;
        }
    }
}
