using System.Collections.Generic;

namespace ConsignorMGT.Models
{
    public interface IBuyerRepository
    {
        IEnumerable<Buyer> GetAllBuyers();
        
        bool SaveAll();
        void AddBuyer(Buyer newBuyer);
        Buyer GetBuyerByLastName(string fullName);
    }
}