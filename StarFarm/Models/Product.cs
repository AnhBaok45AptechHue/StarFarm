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

        [Required]
        [StringLength(50)]
        public string Product_Name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Category_Id { get; set; }

        [StringLength(50)]
        public string Flavor { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Image { get; set; }
        [Required]
        [StringLength(50)]
        public string Image2 { get; set; }
        [StringLength(50)]
        // Không mapping field này với DB (do trong DB không có)
        [NotMapped]
        public HttpPostedFileBase UploadFile1 { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadFile2 { get; set; }
       
       
        //{
        //    get
        //    {
        //        var featuredImage = ProductImages.Where(it => it.IsFeatured).FirstOrDefault();
        //        if (ProductImages.Count == 0 || featuredImage == null) { return ""; };
        //        return featuredImage.ImageUrl;
        //    }
        //}
        //[NotMapped]
        //public ProductImage FeaturedImageObject
        //{
        //    get
        //    {
        //        var featuredImage = ProductImages.Where(it => it.IsFeatured).FirstOrDefault();
        //        if (ProductImages.Count == 0 || featuredImage == null) { return new ProductImage { ImageUrl = string.Empty }; };
        //        return featuredImage;
        //    }
        //}

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ProductImage> ProductImages { get; set; }

        //public virtual ProductFeature ProductFeature { get; set; }
    }
}
