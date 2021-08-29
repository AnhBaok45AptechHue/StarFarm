namespace StarFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal Category_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Category_Name { get; set; }

        public virtual Category Category1 { get; set; }

        public virtual Category Category2 { get; set; }

        public virtual Category Category11 { get; set; }

        public virtual Category Category3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
