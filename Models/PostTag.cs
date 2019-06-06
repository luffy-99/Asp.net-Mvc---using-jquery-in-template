namespace Models
{
    using Models.Abstact;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("PostTags")]
    public partial class PostTag : Auditable
    {
        [Key]
        [Column(Order = 0)]
        public int PostID { set; get; }

        [Key]
        [Column(TypeName = "varchar", Order = 1)]
        [MaxLength(50)]
        public string TagID { set; get; }

        [ForeignKey("PostID")]
        public virtual Post Post { set; get; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { set; get; }
    }
}
