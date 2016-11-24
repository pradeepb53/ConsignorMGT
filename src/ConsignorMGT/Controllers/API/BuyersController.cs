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
    [Route("api/buyers")]
    public class BuyersController: Controller
    {
        private ILogger<BuyersController> _logger;
        private IBuyerRepository _repository;

        public BuyersController(IBuyerRepository repository, ILogger<BuyersController> logger )
        {
            _repository = repository;
            _logger = logger;   
        }


        [HttpGet("{lastName}")]
        public JsonResult Get(string lastName)
        {
            try
            {
                var results = Mapper.Map<BuyerViewModel>(_repository.GetBuyerByLastName(lastName));
                return Json(results);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new Buyer", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
               
            }
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var results = Mapper.Map<IEnumerable<BuyerViewModel>>(_repository.GetAllBuyers());
            return Json(results);
        }



        [HttpPost("")]
        public JsonResult Post([FromBody] BuyerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    var newBuyer = Mapper.Map<Buyer>(viewModel);
                    _logger.LogInformation("Attemping to save new Buyer");
                    _repository.AddBuyer(newBuyer);

                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<BuyerViewModel>(newBuyer));
                    }
                    
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Failed to save new Buyer", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            return Json("Failed!");
            
        }
    }
}
