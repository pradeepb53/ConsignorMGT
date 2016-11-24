using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsignorMGT.ViewModels
{
    public class ContractDetailViewModel
    {
        [Required]
        public string Manufacture { get; set; }
        [Required]
        public string Model { get; set; }
        public int RandRBudget { get; set; }
        public int SurchargeRate { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
