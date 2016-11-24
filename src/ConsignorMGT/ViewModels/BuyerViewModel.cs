using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsignorMGT.ViewModels
{
    public class BuyerViewModel
    {
        //public int BuyerID { get; set; }
        [Required]
        [StringLength(255, MinimumLength =5)]    
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
           private  set { }
        }
    }
}
