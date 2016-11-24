using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ConsignorMGT.Models
{
    public class ContractHeader
    {
        public int ContractHeaderID { get; set; }
        public string ConsignorCode { get; set; }
        public int EventNumber { get; set; }
        public string Type { get; set; }
        public DateTime DateSigned { get; set; }
        public ICollection<ContractDetail> ContractDetails { get; set; }

    }
}
