using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LocadoraWebApi.Models
{
    [Table("locacao")]
    public class Locacao
    {
        [Key]
        public int Id { get; set; }
        //[ForeignKey(nameof(ClienteId))]
        public int ClienteId { get; set; }
        //[ForeignKey(nameof(FilmeId))]
        public int FilmeId { get; set; }
        public DateTime DataLocacao { get; set; }

        public DateTime DataDevolucao { get; set; }

        
        //[InverseProperty("Locacaos")]
        [JsonIgnore]
        public virtual Filme? Filme { get; set; }
        
        //[InverseProperty("Locacaos")]
        [JsonIgnore]
        public virtual Cliente? Cliente { get; set; }

    }
}
