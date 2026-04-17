using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LH_PET_WEB.Models
{
    [Table("tb_fornecedor")]
    public class Fornecedor
    {
        [Key]
        [Column("pk_fornecedor")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("nm_fornecedor")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [MaxLength(18)]
        [Column("cd_cnpj")]
        public string Cnpj { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        [Column("nm_email")]
        public string Email { get; set; } = string.Empty;
    }
}