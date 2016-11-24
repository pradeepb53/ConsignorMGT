using AutoMapper;
using ConsignorMGT.Models;
using ConsignorMGT.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ConsignorMGT.Controllers.API
{
    [Route("api/contractsheader/{consignorCode}/{eventNumber}/contractsdetail")]
    public class ContractsDetailController : Controller
    {
        private ILogger<ContractsDetailController> _logger;
        private IContractRepository _repository;

        public ContractsDetailController(IContractRepository repository, ILogger<ContractsDetailController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")] //Get header and details for a given consignor/event
        public  JsonResult Get(string consignorCode, int eventNumber)
        {
            try
            {
                
                var results = _repository.GetContractHeaderAndDetailsByConsignorCodeAndEventNumber(consignorCode, eventNumber);
                
                
                if (results == null)
                {
                    return Json(null);
                }
                return Json(Mapper.Map<IEnumerable<ContractHeaderViewModel>>(results));
               // return Json(results);
            }

            catch (Exception ex)
            {

                _logger.LogError("Failed to contracts detail for header ", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message, Text = "Does not work!" });
            }
            
        }

        [HttpPost("")]
        public JsonResult Post(string consignorCode, int eventNumber, [FromBody] ContractDetailViewModel viewModel)
        {
            

            try
            {
                if (ModelState.IsValid)
                {
                    var contractHeader = _repository.GetContractHeaderByCosignorCodeAndEventNumber(consignorCode, eventNumber);

                    if (contractHeader == null)
                    {
                        return Json($"Error - Contract Header not found for Consignor->{consignorCode} and Event->{eventNumber}");
                    }
                    // Map to the Entity
                    var newDetail = Mapper.Map<ContractDetail>(viewModel);

                    //Save to Database
                    _repository.AddContractDetail(consignorCode, eventNumber, newDetail);

                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<ContractDetailViewModel>(newDetail));
                    }
                    
                }

                
            }

            catch (Exception ex)
            {
                _logger.LogError("Failed to save new contracts detail", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message, Text = "Did not work!" });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Model Validation Failed!");
        }
    }
    
}
