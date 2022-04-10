﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoWebApi.Models
{
    [Table("filme")]
    public class Filme
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string? Titulo { get; set; }
        public int ClassificacaoIndicativa { get; set; }
        public bool Lancamento { get; set; }

        [InverseProperty(nameof(Locacao.Filme))]
        public virtual ICollection<Locacao>? Locacaos { get; set; }
    }
}