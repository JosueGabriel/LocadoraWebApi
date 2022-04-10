using LocacaoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LocacaoWebApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Filme>? Filmes { get; set; }
        public DbSet<Locacao>? Locacaos { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    }
}
