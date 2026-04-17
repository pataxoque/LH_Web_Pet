using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LH_PET_WEB.Models
{
    [Table("tb_usuario")]
    public class Usuario
    {
        [Key]
        [Column("pk_usuario")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("nm_usuario")]
        public string Nome { get; set; } = "Usuário do Sistema";

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        [Column("nm_email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column("ds_senha_hash")]
        public string SenhaHash { get; set; } = string.Empty;

        [Column("fl_senha_temporaria")]
        public bool SenhaTemporaria { get; set; } = false;

        [Required]
        [MaxLength(50)]
        [Column("ds_perfil")]
        public string Perfil { get; set; } = "Funcionario";

        [Column("fl_ativo")]
        public bool Ativo { get; set; } = true;
    }
}