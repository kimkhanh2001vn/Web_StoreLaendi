using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaendiStore.Data.EF
{
    [Table("User")]
    public class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Stores = new HashSet<Store>();
        }
        [Key]
        public int UserID { get; set; }

        [StringLength(256)]
        public string UserName { get; set; }

        [StringLength(256)]
        public string PassWord { get; set; }

        [StringLength(256)]
        public string Role { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        public double NumberPhone { get; set; }

        [StringLength(256)]
        public string Address { get; set; }

        [StringLength(256)]
        public string Nation { get; set; }

        [StringLength(256)]
        public string MyWork { get; set; }

        public bool? Status { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        public string Images { get; set; }

        public DateTime? CreateDate { get; set; }
        public virtual ICollection<Store> Stores { get; set; } 
    }
}
