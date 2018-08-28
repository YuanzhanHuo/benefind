using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Benefind.Models;

namespace Benefind.Controllers
{
    public class Ndis201819Controller : Controller
    {
        private readonly DbBenefit _context;

        public Ndis201819Controller(DbBenefit context)
        {
            _context = context;
        }

        // GET: Ndis201819
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ndis201819.ToListAsync());
        }

        // GET: Ndis201819/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ndis201819 = await _context.Ndis201819
                .FirstOrDefaultAsync(m => m.SupportItemNumber == id);
            if (ndis201819 == null)
            {
                return NotFound();
            }

            return View(ndis201819);
        }

        // GET: Ndis201819/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ndis201819/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistrationGroup,SupportItemNumber,SupportItem,SupportItemDescription,UnitOfMeasure,Quote,PriceLimit,PriceControl,SupportCategories,SupportCategoryNumber")] Ndis201819 ndis201819)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ndis201819);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ndis201819);
        }

        // GET: Ndis201819/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ndis201819 = await _context.Ndis201819.FindAsync(id);
            if (ndis201819 == null)
            {
                return NotFound();
            }
            return View(ndis201819);
        }

        // POST: Ndis201819/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RegistrationGroup,SupportItemNumber,SupportItem,SupportItemDescription,UnitOfMeasure,Quote,PriceLimit,PriceControl,SupportCategories,SupportCategoryNumber")] Ndis201819 ndis201819)
        {
            if (id != ndis201819.SupportItemNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ndis201819);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Ndis201819Exists(ndis201819.SupportItemNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ndis201819);
        }

        // GET: Ndis201819/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ndis201819 = await _context.Ndis201819
                .FirstOrDefaultAsync(m => m.SupportItemNumber == id);
            if (ndis201819 == null)
            {
                return NotFound();
            }

            return View(ndis201819);
        }

        // POST: Ndis201819/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ndis201819 = await _context.Ndis201819.FindAsync(id);
            _context.Ndis201819.Remove(ndis201819);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Ndis201819Exists(string id)
        {
            return _context.Ndis201819.Any(e => e.SupportItemNumber == id);
        }
    }
}
