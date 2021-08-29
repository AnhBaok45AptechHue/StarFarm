namespace StarFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ContactU
    {
        [Column("User Name")]
        [Required]
        [StringLength(50)]
        public string User_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        public string Message { get; set; }

        public long ID { get; set; }
    }
}
