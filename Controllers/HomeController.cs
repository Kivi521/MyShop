using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderManagementSystemNew.Models;
using OrderManagementSystemNew.Services;
using Microsoft.AspNetCore.Authorization;
using OrderManagementSystemNew.Data;
using OrderManagementSystemNew.Data.Entity;

namespace OrderManagementSystemNew.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly IMailService _mailService;
        private readonly ILogger<StockItemController> _logger;
        private readonly DataRepository _dataRepository;


        public HomeController(IMailService mailService, ILogger<StockItemController> logger, DataRepository dataRepository)
        {
            _mailService = mailService;
            ViewBag.UserMessage = "Mail Sent...";
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Tile = "Contact Us";
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage("yisomi102@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent...";//和contact html最底下的viewbag div连接，这样可以显示在页面上
                ModelState.Clear();//每次send成功后，clear表格
            }
            else
            {
                //show the errors,view will do this for me
            }

            return View();
        }

        
        public IActionResult About()
        {
            ViewBag.Tile = "About Us"; 
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

       // [HttpGet("shop")]


        //[Authorize]
        public IActionResult Shop()
        {
            //var results = _dataRepository.GetAllProducts();

            //return View(results);
            return View();
        }
    }
}
  