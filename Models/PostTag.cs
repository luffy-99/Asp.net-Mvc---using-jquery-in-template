namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PostTag
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string TagID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }

        public bool Status { get; set; }

        public virtual Post Post { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
