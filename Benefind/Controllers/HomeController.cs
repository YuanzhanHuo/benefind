using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Benefind.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Benefind.Controllers
{   
    public class HomeController : Controller
    {
        private readonly DbBenefit _context;

        public HomeController(DbBenefit context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WhatisNDIS()
        {
            return View("WhatisNDIS");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();

        }

        public IActionResult JoinNDIS()
        {

            return View("JoinNDIS");
        }

        public async Task<IActionResult> Benefits(int? category)
        {
            var benefits = from b in _context.Ndis201819
                           select b;
            if (!String.IsNullOrEmpty(category.ToString()))
            {
                benefits = benefits.Where(b => b.SupportCategoryNumber.Contains(category.ToString()));
                return View(await benefits.AsNoTracking().ToListAsync());
            }
            return View(await _context.Ndis201819.ToListAsync());
            //return View("Benefits");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
