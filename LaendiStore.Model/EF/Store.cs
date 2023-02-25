using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaendiStore.Data.EF
{
    public class Store
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Store()
        {
            Shippers = new HashSet<Shipper>();
        }
        [Key]
        public int StoreID { get; set; }
        [StringLength(256)]
        public string StoreName { get; set; }
        [StringLength(256)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public int UserID { get; set; }

        [ForeignKey("FK_User")]
        public virtual User User { get; set; }
        public virtual ICollection<Shipper> Shippers { get; set; }
    }
}
