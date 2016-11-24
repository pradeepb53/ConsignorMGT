using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConsignorMGT.Models
{
    public class Buyer
    {
        public int BuyerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }
}
