using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaendiStore.Data.EF
{
    [Table("Customer")]
    public class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        [Key]
        public int CustomerID { get; set; }

        [StringLength(256)]
        public string UserName { get; set; }

        [StringLength(256)]
        public string PassWord { get; set; }

        [StringLength(256)]
        public string CustomerName { get; set; }

        [StringLength(256)]
        public string CustomerAddress { get; set; }

        [StringLength(256)]
        public string CustomerWork { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        public bool? Status { get; set; }

        [StringLength(256)]
        public string CustomerEmail { get; set; }

        public int? NumberPhone { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(256)]
        public string Avata { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
