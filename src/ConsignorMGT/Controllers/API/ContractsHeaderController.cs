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
    [Route("api/contractsheader")]
    public class ContractsHeaderController : Controller
    {
        private ILogger<ContractsHeaderController> _logger;
        private IContractRepository _repository;

        public ContractsHeaderController(IContractRepository repository, ILogger<ContractsHeaderController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        //Get contract headers with all contract details - This is the default Get()

        [HttpGet("")]
        public JsonResult Get()
        {
            var results = Mapper.Map<IEnumerable<ContractHeaderViewModel>>(_repository.GetAllContractHeadersWithDetails());
            return Json(results);

        }

        //Get contract header and details for a given consignor and event - This is the Get() with parameter values

        [HttpGet("{consignorCode}/{eventNumber}")]
        public JsonResult Get(string consignorCode, int eventNumber)
        {
            try
            {
                var results = Mapper.Map<ContractHeaderViewModel>(_repository.GetContractHeaderByCosignorCodeAndEventNumber(consignorCode, eventNumber));
                return Json(results);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get contract headers for {consignorCode} {eventNumber}", ex);
            }

            return Json("Failed!");
        }
        [HttpPost("")]
        public JsonResult Post([FromBody] ContractHeaderViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var newHeader = Mapper.Map<ContractHeader>(viewModel);
                    _logger.LogInformation("Attemping to save new Contract Header");
                    _repository.AddContractHeader(newHeader);

                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<ContractHeaderViewModel>(newHeader));
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new Contract Header", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message, Text = "Does not work!" });
            }

            return Json("Failed!");

        }
    }
}
