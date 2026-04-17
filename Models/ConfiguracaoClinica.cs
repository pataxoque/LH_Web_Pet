using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LH_PET_WEB.Models
{
    [Table("tb_configuracao_clinica")]
    public class ConfiguracaoClinica
    {
        [Key]
        [Column("pk_configuracao")]
        public int Id { get; set; }

        [Required]
        [Column("tm_abertura")]
        public TimeSpan HoraAbertura { get; set; }

        [Required]
        [Column("tm_fechamento")]
        public TimeSpan HoraFechamento { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("ds_dias_trabalho")]
        public string DiasTrabalho { get; set; } = "1,2,3,4,5"; // 1=Segunda, etc.

        [Column("vl_minutos_consulta")]
        public int MinutosConsulta { get; set; } = 30;
    }
}