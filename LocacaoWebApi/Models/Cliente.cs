using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoWebApi.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200, ErrorMessage = "Nome maior que 200 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(11, ErrorMessage = "")]
        public string CPF { get; set; } = string.Empty;

        public DateTime DataNascimento { get; set; }

        // prop nav
        // public ICollection<Locacao> Locacoes { get; set; } = null!;
    }
}
