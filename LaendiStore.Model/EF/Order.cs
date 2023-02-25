using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaendiStore.Data.EF
{
    [Table("Order")]
    public class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        public int OrderID { get; set; }

        [Required]
        [StringLength(256)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(256)]
        public string CustomerAddress { get; set; }

        [Required]
        [StringLength(256)]
        public string CustomerEmail { get; set; }

        [StringLength(256)]
        public string CustomerMobile { get; set; }

        [StringLength(256)]
        public string PaymentMethod { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(256)]
        public string CreatedBy { get; set; }

        [StringLength(256)]
        public string PaymentStatus { get; set; }
        public int Status { get; set; }
        
        public int ShipperID { get; set; }
        
        public int? CustomerId { get; set; }

        [ForeignKey("FK_Customer")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("FK_Shipper")]
        public virtual Shipper Shipper { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
