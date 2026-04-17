using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LH_PET_WEB.Models
{
    [Table("tb_pet")]
    public class Pet
    {
        [Key]
        [Column("pk_pet")]
        public int Id { get; set; }

        [Required]
        [Column("fk_cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("nm_pet")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column("ds_especie")]
        public string Especie { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column("ds_raca")]
        public string Raca { get; set; } = string.Empty;

        [Required]
        [Column("dt_nascimento")]
        public DateTime DataNascimento { get; set; } = new DateTime(2023, 01, 01);
    }
}