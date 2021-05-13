using CarRental.Business.Abstract;
using CarRental.MVCWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.MVCWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IColorService _colorService;

        public HomeController(ILogger<HomeController> logger, IColorService colorService)
        {
            _logger = logger;
            this._colorService = colorService;
        }

        public IActionResult Index()
        {
            _colorService.Add(new Entity.Concrete.Color { Name = "Kırmızı" });

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
