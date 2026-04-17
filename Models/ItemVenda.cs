using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LH_PET_WEB.Models
{
    [Table("tb_item_venda")]
    public class ItemVenda
    {
        [Key]
        [Column("pk_item_venda")]
        public int Id { get; set; }

        [Required]
        [Column("fk_venda")]
        public int VendaId { get; set; }

        [ForeignKey("VendaId")]
        public Venda? Venda { get; set; }

        [Required]
        [Column("fk_produto")]
        public int ProdutoId { get; set; }

        [Column("qt_vendida")]
        public int Quantidade { get; set; }

        [Column("vl_unitario")]
        public decimal PrecoUnitario { get; set; }
    }
}