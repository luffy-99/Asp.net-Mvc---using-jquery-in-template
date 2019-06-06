namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("MenuGroups")]
    public partial class MenuGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        public virtual IEnumerable<Menu> Menus { set; get; }
    }
}
