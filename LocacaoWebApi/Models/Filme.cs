using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoWebApi.Models
{
    [Table("filme")]
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "")]
        public string Titulo { get; set; } = string.Empty;

        public int ClassificacaoIndicativa { get; set; }

        public bool Lancamento { get; set; }

        // prop nav
        // public ICollection<Locacao> Locacaos { get; set; } = null!;
    }
}
