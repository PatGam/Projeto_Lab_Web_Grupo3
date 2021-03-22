using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Controllers
{
    public class Top10 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
