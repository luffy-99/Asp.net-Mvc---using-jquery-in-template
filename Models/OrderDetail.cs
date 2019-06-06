namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("OrderDetails")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        public int OrderID { set; get; }

        [Key]
        [Column(Order = 1)]
        public int ProductID { set; get; }

        public int Quantitty { set; get; }

        [ForeignKey("OrderID")]
        public virtual Order Order { set; get; }

        [ForeignKey("ProductID")]
        public virtual Product Product { set; get; }
    }
}
