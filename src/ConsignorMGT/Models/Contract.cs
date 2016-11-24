using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsignorMGT.Models
{
    public class Contract
    {
        public int ContractID { get; set; }
        public string OwnerCode { get; set; }
        public string Type { get; set; }
        public int EventID { get; set; }
        public virtual Event Events { get; set; }
        public int ConsignorID { get; set; }
        public virtual Consignor Consignors { get; set; }
    }
}
