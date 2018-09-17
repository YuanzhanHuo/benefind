using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Benefind.Controllers
{
    public class GuideController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Access()
        {
            return View();
        }

        public IActionResult Eligbility()
        {
            return View();
        }
    }
}