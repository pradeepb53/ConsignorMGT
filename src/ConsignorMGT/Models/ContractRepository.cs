using ConsignorMGT.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsignorMGT.Models
{
    public class ContractRepository : IContractRepository
    {
        private ApplicationDbContext _context;

        public ContractRepository(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public void AddContractDetail(string consignorCode, int eventNumber, ContractDetail newDetail)
        {
            var contractHeader = GetContractHeaderByCosignorCodeAndEventNumber(consignorCode, eventNumber);
            newDetail.ContractHeaderID = contractHeader.ContractHeaderID;
            _context.Add(newDetail);
        }
    
        
        public void AddContractHeader(ContractHeader newHeader)
        {
            _context.Add(newHeader);
        }


        
        public ContractHeader GetContractHeaderByCosignorCodeAndEventNumber(string consignorCode, int eventNumber)
        {
            return _context.ContractHeader.Where(c => c.ConsignorCode == consignorCode && c.EventNumber == eventNumber)
                    .FirstOrDefault(); 
         }

        
        public IEnumerable<ContractHeader> GetAllContractHeadersWithDetails()
        {
            return _context.ContractHeader.Include(c => c.ContractDetails)
                                           .ToList();
        }


        public IEnumerable<ContractHeader> GetContractHeaderAndDetailsByConsignorCodeAndEventNumber(string consignorCode, int eventNumber)
        {
            return _context.ContractHeader.Where(c => c.ConsignorCode == consignorCode && c.EventNumber == eventNumber)
                                          .Include(c => c.ContractDetails).ToList();    
        }


        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

       
    }
}
