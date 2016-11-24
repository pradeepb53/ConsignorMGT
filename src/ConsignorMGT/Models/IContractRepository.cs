using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsignorMGT.Models
{
    public interface IContractRepository
    {
        IEnumerable<ContractHeader> GetAllContractHeadersWithDetails();

        void AddContractHeader(ContractHeader newHeader);

        void AddContractDetail(string consignorCode, int eventNumber, ContractDetail newDetail);   
       
        ContractHeader GetContractHeaderByCosignorCodeAndEventNumber(string consignorCode, int eventNumber);

        IEnumerable<ContractHeader> GetContractHeaderAndDetailsByConsignorCodeAndEventNumber(string consignorCode, int eventNumber);

        bool SaveAll();

    }
}
