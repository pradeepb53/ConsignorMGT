using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsignorMGT.Models
{
    public class Payments
    {
        public int PaymentID { get; set; }
        public string OwnerCode { get; set; }
        public DateTime PaymentDate { get; set; }

        [DataType(DataType.Currency)]
        public int Amount { get; set; }

        public string Payable { get; set; }
    }
}
