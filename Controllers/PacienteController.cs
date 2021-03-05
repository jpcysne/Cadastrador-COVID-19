using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastrador_COVID_19.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
