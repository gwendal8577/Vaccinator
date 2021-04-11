using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Vaccinator.Models;

namespace Vaccinator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return
                View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TestAction()
        {
            //Construction d'un modèle
            //var headers = new Dictionary<string, string>();

            //foreach (var item in Request.Headers)
            //{
            //    headers.Add(item.Key, item.Value);
            //}
            var headers = Request.Headers.ToDictionary(item => item.Key, item => item.Value.ToList());

            ViewData["Title"] = "Test Action";

            return View(headers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
