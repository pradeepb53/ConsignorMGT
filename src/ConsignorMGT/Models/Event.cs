using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsignorMGT.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
