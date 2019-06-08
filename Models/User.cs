namespace Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { set; get; }
        [MaxLength(50)]
        public string Name { set; get; }
        [MaxLength(50)]
        [Required]
        public string UserName { set; get; }

        [MaxLength(50)]
        [Required]
        public string PassWord { set; get; }
        [Required]
        [MaxLength(50)]
        public string Position { set; get; }
    }
}
