using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_Lab_Web_Grupo3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Clientes()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Servicos()
        {
            return View();
        }
        public IActionResult Funcionarios()
        {
            return View();
        }

        public IActionResult Gestao()
        {
            return View();
        }

        public IActionResult PacotesBase()
        {
            return View();
        }

        public IActionResult VistaContact()
        {
            return View();
        }

        public IActionResult TVBase()
        {
            return View();
        }

        public IActionResult AdminOp()
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
