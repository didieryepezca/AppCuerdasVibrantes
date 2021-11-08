using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppCuerdasVibrantes.Models;

using AppCuerdasVibrantes.Data.DataAccess;
using Microsoft.AspNetCore.Authorization;


namespace AppCuerdasVibrantes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index(string nombre = "", string accion = "")
        {
            CuerdasDA da = new CuerdasDA();

            string vAccion = "";

            if (!String.IsNullOrWhiteSpace(nombre))
            {
                vAccion = accion;
            }
            var model = da.GetAll(nombre, vAccion);

            return View(model);
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
