using LocacaoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LocacaoWebApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Filme> Filmes { get; set; } = null!;
        public DbSet<Locacao> Locacaos { get; set; } = null!;

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Cliente>()
                .HasMany<Locacao>(c => c.Locacoes)
                .WithOne(x => x.Cliente)
                .HasForeignKey(c => c.Id_Cliente);

            modelBuilder.Entity<Filme>()
                .HasMany<Locacao>(c => c.Locacaos)
                .WithOne(x => x.Filme)
                .HasForeignKey(c => c.Id_Filme);
            /*
            modelBuilder.Entity<Locacao>()
                .HasOne<Cliente>(c => c.Cliente)
                .WithMany(x => x.Locacoes)
                .HasForeignKey(c => c.Id_Cliente);

            modelBuilder.Entity<Locacao>()
                .HasOne<Filme>(c => c.Filme)
                .WithMany(x => x.Locacaos)
                .HasForeignKey(c => c.Id_Filme);
            
        }*/
    }
}
