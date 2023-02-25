using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaendiStore.Data.EF
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int? ColorId { get; set; }

        public int? SizeId { get; set; }
        [ForeignKey("FK_Product")]
        public virtual Product Product { get; set; }
        [ForeignKey("FK_Order")]
        public virtual Order Order { get; set; }
    }
}
