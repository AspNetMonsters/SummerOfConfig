using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ConfigFromAnywhere.Controllers
{
    public class HomeController : Controller
    {
        private IConfigurationRoot _config;

        public HomeController(IConfigurationRoot config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            ViewBag.ButtonEnabled = !bool.Parse(_config["ButtonIsDisabled"]);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
