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
        [Key]
        [Column(TypeName = "numeric")]
        public decimal Category_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Category_Name { get; set; }
    }
}
