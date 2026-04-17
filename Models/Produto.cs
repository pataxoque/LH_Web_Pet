using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LH_PET_WEB.Models
{
    [Table("tb_produto")]
    public class Produto
    {
        [Key]
        [Column("pk_produto")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("nm_produto")]
        public string Nome { get; set; } = string.Empty;

        [Column("ds_produto")]
        public string? Descricao { get; set; }

        [Required]
        [Column("vl_preco")]
        public decimal Preco { get; set; }

        [Column("qt_estoque")]
        public int Estoque { get; set; }

        [Column("nm_imagem_url")]
        public string? ImagemUrl { get; set; }
    }
}