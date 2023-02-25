using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaendiStore.Data.EF
{
    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Alias { get; set; }
        public int CategoryID { get; set; }

        [StringLength(256)]
        public string Image { get; set; }

        [StringLength(256)]
        public string MoreImage { get; set; }

        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Warranty { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        [StringLength(256)]
        public string Content { get; set; }

        public int ViewCount { get; set; }

        [StringLength(256)]
        public string Tags { get; set; }

        [StringLength(256)]
        public string Code { get; set; }

        [StringLength(256)]
        public string Brand { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(256)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(256)]
        public string UpdatedBy { get; set; }

        [StringLength(256)]
        public string MetaKeyword { get; set; }

        [StringLength(256)]
        public string MetaDescription { get; set; }

        public bool Status { get; set; }
        [ForeignKey("FK_Product_Category")]
        public virtual Category category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
