using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsignorMGT.ViewModels
{
    public class ContractHeaderViewModel
    {
        [StringLength(3, MinimumLength =3)]
        public string ConsignorCode { get; set; }
        public int EventNumber { get; set; }
        public string Type { get; set; }
        public DateTime DateSigned { get; set; }


        public IEnumerable<ContractDetailViewModel> ContractDetails { get; set; }
    }
}
