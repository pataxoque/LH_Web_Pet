using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LH_PET_WEB.Models
{
    [Table("tb_agendamento")]
    public class Agendamento
    {
        [Key]
        [Column("pk_agendamento")]
        public int Id { get; set; }

        [Required]
        [Column("fk_pet")]
        public int PetId { get; set; }

        [ForeignKey("PetId")]
        public Pet? Pet { get; set; }

        [Required]
        [Column("dt_agendamento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DataHora { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("ds_servico")]
        public string Servico { get; set; } = "Consulta"; // Ex: Banho, Tosa, Vacina

        [Required]
        [MaxLength(20)]
        [Column("ds_status")]
        public string Status { get; set; } = "Pendente"; // Pendente, Concluído, Cancelado
    }
}