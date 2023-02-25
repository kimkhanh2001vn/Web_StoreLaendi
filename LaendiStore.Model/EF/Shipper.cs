using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaendiStore.Data.EF
{
    public class Shipper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }
        [Key]
        public int ShipperID { get; set; }
        [StringLength(256)]
        public string ShipperName { get; set; }
        [StringLength(256)]
        public string Company { get; set; }
        public double NumberPhone { get; set; }
        
        public int StoreID { get; set; }
        [ForeignKey("FK_Store")]
        public virtual Store Store { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
