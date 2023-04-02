using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EShop.Data.Entity;
using EShop.Data;

namespace EShop.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/Json")]
    public class EBookController : ControllerBase
    {
        private readonly ILogger<EBookController> _logger;
        private readonly DataRepository _dataRepository;
        public EBookController(ILogger<EBookController> logger, DataRepository dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<EBook>> Get()
        {
            try
            {
                _logger.LogError($"Geting EBooks!");
                IEnumerable<EBook> EBooks = _dataRepository.GetAllEBooks();
                return Ok(EBooks);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get data:{ex}");
                return BadRequest("Failed to get data");
            }
            
        }

        
    }
}
