using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoWebApi.Models
{
    [Table("Locacao")]
    public class Locacao
    {
        [Key]
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        // public Cliente Cliente { get; set; } = null!;
        public int Id_Filme { get; set; }
        // public Filme Filme { get; set; } = null!;
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }      //DataDevolucao = Filme.Lancamento? DataLocacao.AddDays(2) : DataLocacao.AddDays(3);

        private readonly DataContext _context;

        public Locacao(int id, int id_Cliente, int id_Filme, DateTime dataLocacao, DateTime dataDevolucao, DataContext context)
        {
            Id = id;
            Id_Cliente = id_Cliente;
            Id_Filme = id_Filme;
            DataLocacao = dataLocacao;
            DataDevolucao = dataDevolucao;
            _context = context;
        }
    }
}
