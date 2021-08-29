namespace StarFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;


    [Table("Product")]
    public partial class Product
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal Product_Id { get; set; }

        public string Product_Name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Category_Id { get; set; }

        [StringLength(50)]
        public string Flavor { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        public virtual Category Category { get; set; }
    }
}
