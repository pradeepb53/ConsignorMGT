using System;

namespace ConsignorMGT.Models
{
    public class ContractDetail
    {
        public int ContractDetailID { get; set; }
        public string Manufacture { get; set; }
        public string Model { get; set; }
        public int RandRBudget { get; set; }
        public int SurchargeRate { get; set; }
        public DateTime DateCreated { get; set; }
        public int ContractHeaderID { get; set; }
    }
}