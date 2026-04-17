using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LH_PET_WEB.Validations;

namespace LH_PET_WEB.Models
{
    [Table("tb_cliente")]
    public class Cliente
    {
        [Key]
        [Column("pk_cliente")]
        public int Id { get; set; }

        [Required]
        [Column("fk_usuario")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("nm_cliente")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [Cpf] // Regra personalizada do PDF de Validations
        [Column("cd_cpf")]
        public string Cpf { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        [Column("cd_telefone")]
        public string Telefone { get; set; } = string.Empty;
    }
}