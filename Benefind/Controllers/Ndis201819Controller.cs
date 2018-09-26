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
        public async Task<IActionResult> Index(int? category)
        {
            var benefits = from b in _context.Ndis201819
                           select b;
            if (!String.IsNullOrEmpty(category.ToString()))
            {
                benefits = benefits.Where(b => b.SupportCategoryNumber.Contains(category.ToString()));
                return View(await benefits.AsNoTracking().ToListAsync());
            }
            return View(await _context.Ndis201819.ToListAsync());
        }

        //GET: filter result datatable
        public JsonResult FilterResultAll()
        {
            var benefits = from b in _context.Ndis201819
                           select b;
            List<Ndis201819> resultList = new List<Ndis201819>();
            resultList = benefits.ToList<Ndis201819>();
            return Json(resultList);

        }


        [HttpPost]
        public JsonResult Filter([FromBody] IList<QuizeViewModel> model)
        {
            IEnumerable<Ndis201819> benefits = from b in _context.Ndis201819
                           select b;
            IEnumerable<Ndis201819> result = from b in _context.Ndis201819
                         where b.SupportItemNumber == "14_031_0127_8_3" || b.SupportItemNumber == "14_032_0127_8_3"
                         || b.SupportItemNumber == "14_033_0127_8_3"    || b.SupportItemNumber == "14_034_0127_8_3"
                         || b.SupportItemNumber == "15_048_0128_1_3" 
                         select b;

            if (model[0].Option.Equals("st6"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where
                                            //early child
                                            b.SupportItemNumber == "15_039_0118_1_3" || b.SupportItemNumber == "15_040_0118_1_3"
                                            || b.SupportItemNumber == "15_041_0118_1_3" 
                                            //child
                                            || b.SupportItemNumber == "05_300303288_0112_1_2"
                                            || b.SupportItemNumber == "05_223088289_0112_1_2" || b.SupportItemNumber == "05_181210199_0103_1_2"
                                            || b.SupportItemNumber == "05_223088289_0112_1_2" || b.SupportItemNumber == "05_180939184_0103_1_2"
                                            || b.SupportItemNumber == "05_122306136_0105_1_2" || b.SupportItemNumber == "05_122306132_0105_1_2"
                                            || b.SupportItemNumber == "05_122306127_0105_1_2" || b.SupportItemNumber == "05_122203114_0105_1_2"
                                            || b.SupportItemNumber == "05_122203107_0105_1_2" || b.SupportItemNumber == "05_121212355_0109_1_2"
                                            || b.SupportItemDescription.Contains("child")


                                            select b;
                result = result.Union(a);
            }
            else if (model[0].Option.Equals("gt6lt18"))
            {
                //result = result.Union(benefits.Where(b => b.SupportItemDescription.Contains("child")));
                result = result.Union(from b in _context.Ndis201819
                         where b.SupportItemNumber == "05_122306127_0105_1_2" || b.SupportItemNumber == "05_122306132_0105_1_2"
                         || b.SupportItemNumber == "05_122306136_0105_1_2" || b.SupportItemNumber == "05_300303288_0112_1_2"
                         || b.SupportItemNumber == "03_092488056_0103_1_1" || b.SupportItemNumber == "03_092403054_0103_1_1"
                          || b.SupportItemNumber == "01_012_0107_1_1" || b.SupportItemNumber == "01_016_0104_1_1"

                         select b);



            }
            else if (model[0].Option.Equals("gt18lt65"))
            {
                result = result.Union(from b in _context.Ndis201819
                                      where b.SupportItemNumber == "03_092403055_0103_1_1" || b.SupportItemNumber == "03_092406061_0103_1_1"
                                      || b.SupportItemNumber == "03_092406062_0103_1_1" || b.SupportItemNumber == "03_092406063_0103_1_1"
                                      || b.SupportItemNumber == "03_092489060_0103_1_1" || b.SupportItemNumber == "03_093021077_0103_1_1"
                                       || b.SupportItemNumber == "05_122306129_0105_1_2" || b.SupportItemNumber == "05_122306125_0105_1_2"

                                      select b);

            }


            // question:Do you need assistance with daily personal activities due to disability?
            if (model[3].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportCategories == "Assistance with daily life (includes Supported Independent Living)"
                                            select b;
                //result = benefits.Where(b => b.SupportCategories.Contains("Assistance with daily life (includes Supported Independent Living)"));
                result = result.Concat(a);
            }
            if (model[4].Option.Equals("yes"))
            {
                result = result.Union(benefits.Where(b => b.SupportCategories.Contains("Transport (auto payments)")));   
            }

            if (model[5].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                      where b.SupportItemNumber == "04_099_0104_6_1" || b.SupportItemNumber == "04_102_0125_6_1"
                                      || b.SupportItemNumber == "04_107_0136_6_1" || b.SupportItemNumber == "04_115_0125_6_1"
                                      || b.SupportItemNumber == "04_146_0104_6_1"
                                      select b;
                result = result.Union(a);
            }

            if (model[6].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "01_001_0101_1_1"

                                            select b;
                result = result.Union(a);
            }

            if (model[7].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "01_001_0101_1_1" || b.SupportItemNumber == "07_001_0106_8_3"
                                            || b.SupportItemNumber == "07_002_0106_8_3" || b.SupportItemNumber == "07_003_0106_8_3"
                                            || b.SupportItemNumber == " 07_004_0106_8_3" || b.SupportItemNumber == "07_005_0106_8_3"
                                            select b;
                result = result.Union(a);
            }

            if (model[8].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "15_035_0106_1_3" 
                                            select b;
                result = result.Union(a);
            }

            if (model[9].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "11_022_0110_7_3" 
                                            select b;
                result = result.Union(a);
            }

            if (model[10].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "15_042_0128_1_3" || b.SupportItemNumber == "15_043_0128_1_3"
                                            || b.SupportItemNumber == "15_044_0128_1_3" || b.SupportItemNumber == "15_045_0128_1_3"
                                            || b.SupportItemNumber == "15_051_0114_1_3"
                                            select b;
                result = result.Union(a);
            }

            if (model[11].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "12_025_0128_3_3" || b.SupportItemNumber == "12_026_0128_3_3"
                                            select b;
                result = result.Union(a);
            }

            if (model[12].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "12_027_0126_3_3" || b.SupportItemNumber == "12_028_0126_3_3"
                                            || b.SupportItemNumber == "12_029_0126_3_3" 
                                            select b;
                result = result.Union(a);
            }

            if (model[13].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "10_017_0102_5_3" || b.SupportItemNumber == "11_022_0110_7_3"
                                            select b;
                result = result.Union(a);
            }

            if (model[14].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "10_011_0128_5_3" || b.SupportItemNumber == "10_015_0133_5_3"

                                            select b;
                result = result.Union(a);
            }

            if (model[15].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "10_012_0133_5_3" || b.SupportItemNumber == "10_013_0133_5_3"
                                            || b.SupportItemNumber == "10_014_0133_5_3" || b.SupportItemNumber == "10_015_0133_5_3"
                                            select b;
                result = result.Union(a);
            }

            if (model[16].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "10_018_0133_5_3" || b.SupportItemNumber == "10_020_0133_5_3"
                                            select b;
                result = result.Union(a);
            }

            if (model[17].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "13_030_0102_4_3" 
                                            select b;
                result = result.Union(a);
            }

            if (model[18].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "15_040_0118_1_3" || b.SupportItemNumber == "15_039_0118_1_3"
                                            || b.SupportItemNumber == "15_041_0118_1_3"
                                            select b;
                result = result.Union(a);
            }

            if (model[19].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "15_038_0117_1_3" 
                                            select b;
                result = result.Union(a);
            }



            //return Json(results, JsonRequestBehavior.AllowGet);
            return Json(result);
        }

        //[HttpGet("Ndis201819/Index/{category}")]
        //public async Task<IActionResult> Category(string category)
        //{
        //    var benefits = from b in _context.Ndis201819
        //                   select b;
        //    if (!String.IsNullOrEmpty(category))
        //    {
        //        benefits = benefits.Where(b => b.SupportCategoryNumber.Equals(category));
        //    }


        //    return View(await benefits.AsNoTracking().ToListAsync());
        //}

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

    public class QuizeViewModel
    {

        public QuizeViewModel() { }

        public string QuizName { get; set; }
        public string Option { get; set; }
    }
}
