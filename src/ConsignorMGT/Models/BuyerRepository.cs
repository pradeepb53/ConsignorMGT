using ConsignorMGT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsignorMGT.Models
{
    public class BuyerRepository: IBuyerRepository
    {
        private ApplicationDbContext _context;

        public BuyerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBuyer(Buyer newBuyer)
        {
            _context.Add(newBuyer);

        }

        public IEnumerable<Buyer> GetAllBuyers()
        {
            return _context.Buyer.OrderBy(b => b.LastName).ToList();
        }

        public Buyer GetBuyerByLastName(string lastName)
        {
            return _context.Buyer.Where(b => b.LastName == lastName).Single();
        }


        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
