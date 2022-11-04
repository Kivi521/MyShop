using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyShop.Data.Entity;
using MyShop.Data;

namespace MyShop.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/Json")]
    public class StockItemController : ControllerBase
    {
        private readonly ILogger<StockItemController> _logger;
        private readonly DataRepository _dataRepository;
        public StockItemController(ILogger<StockItemController> logger, DataRepository dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                _logger.LogError($"Geting products!");
                IEnumerable<Product> products = _dataRepository.GetAllProducts();
                return Ok(products);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get data:{ex}");
                return BadRequest("Failed to get data");
            }
            
        }

        
    }
}
