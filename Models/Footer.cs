namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Footers")]
    public partial class Footer
    {
        [Key]
        [StringLength(250)]
        public string ID { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
