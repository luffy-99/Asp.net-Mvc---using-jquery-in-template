using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Abstact
{
    public class Auditable : IAuditable
    {
        public DateTime? CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public string UpdatedBy { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }
        public bool Status { set; get; }
    }
}
