﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoWebApi.Models
{
    [Table("locacao")]
    public class Locacao
    {
        [Key]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int FilmeId { get; set; }
        public DateTime DataLocacao { get; set; }

        public DateTime DataDevolucao { get; set; }

        [ForeignKey(nameof(FilmeId))]
        [InverseProperty("Locacaos")]
        public virtual Filme? Filme { get; set; }
        [ForeignKey(nameof(ClienteId))]
        [InverseProperty("Locacaos")]
        public virtual Cliente? Cliente { get; set; }

        
    }
}