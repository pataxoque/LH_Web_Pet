using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LH_PET_WEB.Models
{
    [Table("tb_venda")]
    public class Venda
    {
        [Key]
        [Column("pk_venda")]
        public int Id { get; set; }

        [Column("dt_venda")]
        public DateTime DataVenda { get; set; }

        [Column("vl_total")]
        public decimal Total { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("ds_forma_pagamento")]
        public string FormaPagamento { get; set; } = string.Empty;

        public List<ItemVenda> Itens { get; set; } = new List<ItemVenda>();
    }
}