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

            //QUIZL: REAL home modifications
            if (model[20].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "06_183015389_0103_2_2" || b.SupportItemNumber == "06_183015390_0103_2_2"
                                            || b.SupportItemNumber == "06_183015391_0103_2_2" || b.SupportItemNumber == "06_183015392_0103_2_2"
                                            || b.SupportItemNumber == "06_183015393_0103_2_2" || b.SupportItemNumber == "06_183015394_0103_2_2"
                                            || b.SupportItemNumber == "06_183015395_0103_2_2" || b.SupportItemNumber == "06_121703375_0111_2_2"
                                            select b;
                result = result.Union(a);
            }

            if (model[21].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "06_181806381_0111_2_2" || b.SupportItemNumber == "06_181806382_0111_2_2"
                                            || b.SupportItemNumber == "06_182403383_0111_2_2" || b.SupportItemNumber == "06_182488376_0111_2_2"
                                            || b.SupportItemNumber == "06_182488377_0111_2_2" || b.SupportItemNumber == "06_182488378_0111_2_2"
                                            || b.SupportItemNumber == "06_183315404_0111_2_2"
                                            select b;
                result = result.Union(a);
            }

            if (model[22].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "06_182488379_0111_2_2"
                                            select b;
                result = result.Union(a);
            }

            if (model[23].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "06_183003384_0111_2_2" || b.SupportItemNumber == "06_183005385_0111_2_2" || b.SupportItemNumber == "06_183007386_0111_2_2"
                                            || b.SupportItemNumber == "06_183010387_0111_2_2" || b.SupportItemNumber == "06_183011388_0111_2_2" || b.SupportItemNumber == "06_183018396_0111_2_2"
                                            || b.SupportItemNumber == "06_183018397_0111_2_2" || b.SupportItemNumber == "06_183018398_0111_2_2" || b.SupportItemNumber == "06_183018399_0111_2_2"
                                            || b.SupportItemNumber == "06_183018400_0111_2_2" || b.SupportItemNumber == "06_183018401_0111_2_2" || b.SupportItemNumber == "06_183018401_0111_2_2"
                                            || b.SupportItemNumber == "06_183018403_0111_2_2"
                                            select b;
                result = result.Union(a);
            }

            if (model[24].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "06_431_0131_2_2" || b.SupportItemNumber == "06_432_0131_2_2"
                                            select b;
                result = result.Union(a);
            }

            if (model[25].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "06_182488380_0111_2_2"
                                            select b;
                result = result.Union(a);
            }

            // generalised modification support
            if (model[20].Option.Equals("yes") || (model[21].Option.Equals("yes")) || (model[22].Option.Equals("yes")) || (model[23].Option.Equals("yes")) || (model[25].Option.Equals("yes")))
    {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "06_405_0111_2_2" || b.SupportItemNumber == "06_406_0111_2_2"
                                            || b.SupportItemNumber == "06_407_0111_2_2" || b.SupportItemNumber == "06_408_0111_2_2"
                                            select b;
                result = result.Union(a);
            }


            //QUIZ: Consumables
            if (model[26].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "03_050903053_0103_1_1" || b.SupportItemNumber == "03_092403054_0103_1_1" || b.SupportItemNumber == "03_092403055_0103_1_1"
                                            || b.SupportItemNumber == "03_092406057_0103_1_1" || b.SupportItemNumber == "03_092406058_0103_1_1" || b.SupportItemNumber == "03_092406059_0103_1_1"
                                            || b.SupportItemNumber == "03_092406061_0103_1_1" || b.SupportItemNumber == "03_092406062_0103_1_1" || b.SupportItemNumber == "03_092406063_0103_1_1"
                                            || b.SupportItemNumber == "03_092488056_0103_1_1" || b.SupportItemNumber == "03_092489060_0103_1_1" || b.SupportItemNumber == "03_092718064_0103_1_1"
                                            || b.SupportItemNumber == "03_093012065_0103_1_1" || b.SupportItemNumber == "03_093012066_0103_1_1" || b.SupportItemNumber == "03_093012067_0103_1_1"
                                            || b.SupportItemNumber == "03_093012068_0103_1_1" || b.SupportItemNumber == "03_093012069_0103_1_1" || b.SupportItemNumber == "03_093012070_0103_1_1"
                                            || b.SupportItemNumber == "03_093018071_0103_1_1" || b.SupportItemNumber == "03_093018072_0103_1_1" || b.SupportItemNumber == "03_093018073_0103_1_1"
                                            || b.SupportItemNumber == "03_093018074_0103_1_1" || b.SupportItemNumber == "03_093018075_0103_1_1" || b.SupportItemNumber == "03_093018076_0103_1_1"
                                            || b.SupportItemNumber == "03_093018077_0103_1_1" || b.SupportItemNumber == "03_093036132_0103_1_1" || b.SupportItemNumber == "03_093045133_0103_1_1"
                                            || b.SupportItemNumber == "03_710930093_0103_1_1" || b.SupportItemNumber == "03_710930094_0103_1_1"
                                            select b;
                result = result.Union(a);
            }

            if (model[27].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "03_131_0103_1_1" || b.SupportItemNumber == "03_150930084_0103_1_1" || b.SupportItemNumber == "03_150930085_0103_1_1"
                                            || b.SupportItemNumber == "03_150930086_0103_1_1" || b.SupportItemNumber == "03_150930087_0103_1_1"
                                            select b;

                result = result.Union(a);
            }



            if (model[28].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "03_089_0121_1_1" || b.SupportItemNumber == "03_090_0121_1_1" || b.SupportItemNumber == "03_091_0121_1_1"
                                            select b;

                result = result.Union(a);
            }



            //QUIZ: Assistive Technology
            if (model[29].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "05_900101023_0130_1_2"
                                            select b;
                result = result.Union(a);
            }

            if (model[30].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "05_353_0108_1_2" || b.SupportItemNumber == "05_090703371_0109_1_2" || b.SupportItemNumber == "05_121204356_0109_1_2"
                                            || b.SupportItemNumber == "05_121205357_0109_1_2" || b.SupportItemNumber == "05_121207358_0109_1_2" || b.SupportItemNumber == "05_121208359_0109_1_2"
                                            || b.SupportItemNumber == "05_121209360_0109_1_2" || b.SupportItemNumber == "05_121212355_0109_1_2" || b.SupportItemNumber == "05_121212361_0109_1_2"
                                            || b.SupportItemNumber == "05_121215362_0109_1_2" || b.SupportItemNumber == "05_121218363_0109_1_2" || b.SupportItemNumber == "05_121218364_0109_1_2"
                                            || b.SupportItemNumber == "05_121218365_0109_1_2" || b.SupportItemNumber == "05_121218366_0109_1_2" || b.SupportItemNumber == "05_121221354_0109_1_2"
                                            || b.SupportItemNumber == "05_121221367_0109_1_2" || b.SupportItemNumber == "05_121224368_0109_1_2" || b.SupportItemNumber == "05_121227369_0109_1_2"
                                            || b.SupportItemNumber == "05_121230370_0109_1_2" || b.SupportItemNumber == "05_501212373_0109_1_2" 
                                            select b;
                result = result.Union(a);
            }



            if (model[31].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "05_121809102_0112_1_2" || b.SupportItemNumber == "05_121821103_0112_1_2" || b.SupportItemNumber == "05_122203291_0112_1_2"
                                            || b.SupportItemNumber == "05_061826297_0112_1_2" || b.SupportItemNumber == "05_121805101_0112_1_2" || b.SupportItemNumber == "05_121806409_0112_1_2"
                                            || b.SupportItemNumber == "05_122218293_0112_1_2" || b.SupportItemNumber == "05_223088289_0112_1_2" || b.SupportItemNumber == "05_300303288_0112_1_2"
                                            || b.SupportItemNumber == "05_300303290_0112_1_2" || b.SupportItemNumber == "05_300303302_0112_1_2" || b.SupportItemNumber == "05_300309296_0112_1_2"
                                            || b.SupportItemNumber == "05_300900292_0112_1_2" || b.SupportItemNumber == "05_300903294_0112_1_2" || b.SupportItemNumber == "05_300912300_0112_1_2"
                                            || b.SupportItemNumber == "05_308800285_0112_1_2" || b.SupportItemNumber == "05_503000316_0112_1_2" || b.SupportItemNumber == "05_703000332_0112_1_2"
                                            || b.SupportItemNumber == "05_713000342_0112_1_2" || b.SupportItemNumber == "05_803000349_0112_1_2"
                                            select b;

                result = result.Union(a);
            }

            if (model[32].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "05_150600320_0123_1_2" || b.SupportItemNumber == "05_158800321_0123_1_2" || b.SupportItemNumber == "05_222704219_0123_1_2"
                                            || b.SupportItemNumber == "05_222712259_0123_1_2" || b.SupportItemNumber == "05_222716260_0123_1_2" || b.SupportItemNumber == "05_241303281_0123_1_2"
                                            || b.SupportItemNumber == "05_241303282_0123_1_2" || b.SupportItemNumber == "05_241306283_0123_1_2" || b.SupportItemNumber == "05_702413331_0123_1_2"
                                            || b.SupportItemNumber == "05_712413341_0123_1_2" || b.SupportItemNumber == "05_802413323_0123_1_2"
                                            select b;

                result = result.Union(a);
            }

            if (model[33].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "05_801812347_0103_1_2" || b.SupportItemNumber == "05_801809436_0103_1_2"
                                            || b.SupportItemNumber == "05_801288434_0103_1_2" || b.SupportItemNumber == "05_800912344_0103_1_2" || b.SupportItemNumber == "05_718888439_0103_1_2"
                                            || b.SupportItemNumber == "05_711812339_0103_1_2" || b.SupportItemNumber == "05_710912335_0103_1_2" || b.SupportItemNumber == "05_701812329_0103_1_2"
                                            || b.SupportItemNumber == "05_701809338_0103_1_2" || b.SupportItemNumber == "05_701809328_0103_1_2" || b.SupportItemNumber == "05_700912325_0103_1_2"
                                            || b.SupportItemNumber == "05_501812311_0103_1_2" || b.SupportItemNumber == "05_500933306_0103_1_2" || b.SupportItemNumber == "05_181288206_0103_1_2"
                                            || b.SupportItemNumber == "05_223612273_0103_1_2" || b.SupportItemNumber == "05_188800051_0103_1_2" || b.SupportItemNumber == "05_241303281_0123_1_2"
                                            || b.SupportItemNumber == "05_181288205_0103_1_2" || b.SupportItemNumber == "05_181233208_0103_1_2" || b.SupportItemNumber == "05_181227207_0103_1_2"
                                            || b.SupportItemNumber == "05_181227206_0103_1_2" || b.SupportItemNumber == "05_181224204_0103_1_2" || b.SupportItemNumber == "05_181221203_0103_1_2"
                                            || b.SupportItemNumber == "05_180921181_0103_1_2" || b.SupportItemNumber == "05_180939183_0103_1_2" || b.SupportItemNumber == "05_180939184_0103_1_2"
                                            || b.SupportItemNumber == "05_180939187_0103_1_2" || b.SupportItemNumber == "05_181210197_0103_1_2" || b.SupportItemNumber == "05_181210199_0103_1_2"
                                            || b.SupportItemNumber == "05_181210200_0103_1_2" || b.SupportItemNumber == "05_181210201_0103_1_2" || b.SupportItemNumber == "05_181212202_0103_1_2"
                                            || b.SupportItemNumber == "05_098800044_0103_1_2" || b.SupportItemNumber == "05_123109155_0103_1_2" || b.SupportItemNumber == "05_123109156_0103_1_2"
                                            || b.SupportItemNumber == "05_123109157_0103_1_2" || b.SupportItemNumber == "05_123121160_0103_1_2" || b.SupportItemNumber == "05_150300318_0103_1_2"
                                            || b.SupportItemNumber == "05_150900319_0103_1_2" || b.SupportItemNumber == "05_180315322_0103_1_2" || b.SupportItemNumber == "05_180903180_0103_1_2"
                                            || b.SupportItemNumber == "05_093307072_0103_1_2" || b.SupportItemNumber == "05_093307073_0103_1_2" || b.SupportItemNumber == "05_093307074_0103_1_2"
                                            || b.SupportItemNumber == "05_093312075_0103_1_2" || b.SupportItemNumber == "05_093312080_0103_1_2" || b.SupportItemNumber == "05_093312081_0103_1_2"
                                            || b.SupportItemNumber == "05_093318082_0103_1_2" || b.SupportItemNumber == "05_093327083_0103_1_2" || b.SupportItemNumber == "05_093330084_0103_1_2"
                                            || b.SupportItemNumber == "05_091221065_0103_1_2" || b.SupportItemNumber == "05_091221066_0103_1_2" || b.SupportItemNumber == "05_091221067_0103_1_2"
                                            || b.SupportItemNumber == "05_091224068_0103_1_2" || b.SupportItemNumber == "05_091225069_0103_1_2" || b.SupportItemNumber == "05_093300317_0103_1_2"
                                            || b.SupportItemNumber == "05_093303078_0103_1_2" || b.SupportItemNumber == "05_093303079_0103_1_2" || b.SupportItemNumber == "05_093304076_0103_1_2"
                                            || b.SupportItemNumber == "05_093305077_0103_1_2" || b.SupportItemNumber == "05_093307070_0103_1_2" || b.SupportItemNumber == "05_093307071_0103_1_2"
                                            || b.SupportItemNumber == "05_091221065_0103_1_2" || b.SupportItemNumber == "05_091221066_0103_1_2" || b.SupportItemNumber == "05_091221067_0103_1_2"
                                            || b.SupportItemNumber == "05_091224068_0103_1_2" || b.SupportItemNumber == "05_091225069_0103_1_2" || b.SupportItemNumber == "05_093300317_0103_1_2"
                                            || b.SupportItemNumber == "05_093303078_0103_1_2" || b.SupportItemNumber == "05_093303079_0103_1_2" || b.SupportItemNumber == "05_093304076_0103_1_2"
                                            || b.SupportItemNumber == "05_093305077_0103_1_2" || b.SupportItemNumber == "05_093307070_0103_1_2" || b.SupportItemNumber == "05_093307071_0103_1_2"
                                            || b.SupportItemNumber == "05_091203053_0103_1_2" || b.SupportItemNumber == "05_091203054_0103_1_2" || b.SupportItemNumber == "05_091203055_0103_1_2"
                                            || b.SupportItemNumber == "05_091203056_0103_1_2" || b.SupportItemNumber == "05_091203057_0103_1_2" || b.SupportItemNumber == "05_091203058_0103_1_2"
                                            || b.SupportItemNumber == "05_091203059_0103_1_2" || b.SupportItemNumber == "05_091203060_0103_1_2" || b.SupportItemNumber == "05_091212061_0103_1_2"
                                            || b.SupportItemNumber == "05_091212062_0103_1_2" || b.SupportItemNumber == "05_091218063_0103_1_2" || b.SupportItemNumber == "05_091221064_0103_1_2"
                                            || b.SupportItemNumber == "05_043006001_0103_1_2" || b.SupportItemNumber == "05_043306002_0103_1_2" || b.SupportItemNumber == "05_043306003_0103_1_2"
                                            || b.SupportItemNumber == "05_043306004_0103_1_2" || b.SupportItemNumber == "05_043306005_0103_1_2" || b.SupportItemNumber == "05_043318006_0103_1_2"
                                            || b.SupportItemNumber == "05_053603008_0103_1_2" || b.SupportItemNumber == "05_053603009_0103_1_2" || b.SupportItemNumber == "05_053603010_0103_1_2"
                                            || b.SupportItemNumber == "05_090603045_0103_1_2" || b.SupportItemNumber == "05_090900046_0103_1_2" || b.SupportItemNumber == "05_091203047_0103_1_2"
                                            || b.SupportItemNumber == "05_091203048_0103_1_2" || b.SupportItemNumber == "05_091203049_0103_1_2" || b.SupportItemNumber == "05_091203052_0103_1_2"
                                            select b;

                result = result.Union(a);
            }



            if (model[34].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "05_220903233_0124_1_2" || b.SupportItemNumber == "05_220906234_0124_1_2" || b.SupportItemNumber == "05_221224237_0124_1_2"
                                            || b.SupportItemNumber == "05_221833248_0124_1_2" || b.SupportItemNumber == "05_222100249_0124_1_2" || b.SupportItemNumber == "05_222102250_0124_1_2"
                                            || b.SupportItemNumber == "05_222102251_0124_1_2" || b.SupportItemNumber == "05_222103252_0124_1_2" || b.SupportItemNumber == "05_222106253_0124_1_2"
                                            || b.SupportItemNumber == "05_222109254_0124_1_2" || b.SupportItemNumber == "05_222109255_0124_1_2" || b.SupportItemNumber == "05_222109256_0124_1_2"
                                            || b.SupportItemNumber == "05_222421257_0124_1_2" || b.SupportItemNumber == "05_223003279_0124_1_2" || b.SupportItemNumber == "05_223030280_0124_1_2"
                                            || b.SupportItemNumber == "05_223603267_0124_1_2" || b.SupportItemNumber == "05_223612268_0124_1_2" || b.SupportItemNumber == "05_223612269_0124_1_2"
                                            || b.SupportItemNumber == "05_223618270_0124_1_2" || b.SupportItemNumber == "05_223621271_0124_1_2" || b.SupportItemNumber == "05_223621272_0124_1_2"
                                            || b.SupportItemNumber == "05_223907277_0124_1_2" || b.SupportItemNumber == "05_223907278_0124_1_2" || b.SupportItemNumber == "05_242403284_0124_1_2"
                                            || b.SupportItemNumber == "05_502200312_0124_1_2" || b.SupportItemNumber == "05_702288440_0124_1_2" || b.SupportItemNumber == "05_802200437_0124_1_2"
                                            select b;


                result = result.Union(a);
            }


            if (model[35].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "05_060318012_0135_1_2" || b.SupportItemNumber == "05_060606010_0135_1_2" || b.SupportItemNumber == "05_060688011_0135_1_2"
                                            || b.SupportItemNumber == "05_061203015_0135_1_2" || b.SupportItemNumber == "05_061203041_0135_1_2" || b.SupportItemNumber == "05_061203042_0135_1_2"
                                            || b.SupportItemNumber == "05_061203043_0135_1_2" || b.SupportItemNumber == "05_061206016_0135_1_2" || b.SupportItemNumber == "05_061206017_0135_1_2"
                                            || b.SupportItemNumber == "05_061206018_0135_1_2" || b.SupportItemNumber == "05_061206019_0135_1_2" || b.SupportItemNumber == "05_061206020_0135_1_2"
                                            || b.SupportItemNumber == "05_061209021_0135_1_2" || b.SupportItemNumber == "05_061212022_0135_1_2" || b.SupportItemNumber == "05_061213023_0135_1_2"
                                            || b.SupportItemNumber == "05_061215024_0135_1_2" || b.SupportItemNumber == "05_061216025_0135_1_2" || b.SupportItemNumber == "05_061217026_0135_1_2"
                                            || b.SupportItemNumber == "05_061218013_0135_1_2" || b.SupportItemNumber == "05_061218027_0135_1_2" || b.SupportItemNumber == "05_061219028_0135_1_2"
                                            || b.SupportItemNumber == "05_061803029_0135_1_2" || b.SupportItemNumber == "05_061806030_0135_1_2" || b.SupportItemNumber == "05_061809031_0135_1_2"
                                            || b.SupportItemNumber == "05_061815032_0135_1_2" || b.SupportItemNumber == "05_061821033_0135_1_2" || b.SupportItemNumber == "05_062403035_0135_1_2"
                                            || b.SupportItemNumber == "05_062406036_0135_1_2" || b.SupportItemNumber == "05_062409037_0135_1_2" || b.SupportItemNumber == "05_062415038_0135_1_2"
                                            || b.SupportItemNumber == "05_062418039_0135_1_2" || b.SupportItemNumber == "05_062421040_0135_1_2" || b.SupportItemNumber == "05_062488034_0135_1_2"
                                            || b.SupportItemNumber == "05_062488298_0135_1_2" || b.SupportItemNumber == "05_062488299_0135_1_2" || b.SupportItemNumber == "05_500612441_0135_1_2"
                                            || b.SupportItemNumber == "05_500624304_0135_1_2" || b.SupportItemNumber == "05_500624305_0135_1_2" || b.SupportItemNumber == "05_800612438_0135_1_2"
                                            select b;

                result = result.Union(a);
            }

            if (model[36].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "05_220627222_0122_1_2" || b.SupportItemNumber == "05_220627227_0122_1_2" || b.SupportItemNumber == "05_220627228_0122_1_2"
                                            || b.SupportItemNumber == "05_220627230_0122_1_2" || b.SupportItemNumber == "05_220627232_0122_1_2" || b.SupportItemNumber == "05_221830247_0122_1_2"
                                            || b.SupportItemNumber == "05_221836223_0122_1_2" || b.SupportItemNumber == "05_222106442_0122_1_2" || b.SupportItemNumber == "05_222106443_0122_1_2"
                                            || b.SupportItemNumber == "05_222403225_0122_1_2" || b.SupportItemNumber == "05_222421226_0122_1_2" || b.SupportItemNumber == "05_222704266_0122_1_2"
                                            || b.SupportItemNumber == "05_222721231_0122_1_2" || b.SupportItemNumber == "05_222721231_0122_1_2" || b.SupportItemNumber == "05_222721231_0122_1_2"
                                            || b.SupportItemNumber == "05_222721231_0122_1_2" || b.SupportItemNumber == "05_177_0119_1_2" || b.SupportItemNumber == "05_178_0119_1_2"
                                            || b.SupportItemNumber == "05_220600213_0119_1_2" || b.SupportItemNumber == "05_220618229_0119_1_2" || b.SupportItemNumber == "05_220621217_0119_1_2"
                                            || b.SupportItemNumber == "05_220621218_0119_1_2" || b.SupportItemNumber == "05_220621443_0119_1_2" || b.SupportItemNumber == "05_220627221_0119_1_2"
                                            || b.SupportItemNumber == "05_221824246_0119_1_2" || b.SupportItemNumber == "05_352_0119_1_2" || b.SupportItemNumber == "05_502206313_0119_1_2"
                                            select b;

                result = result.Union(a);
            }



            if (model[37].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "05_120303085_0105_1_2" || b.SupportItemNumber == "05_120303086_0105_1_2" || b.SupportItemNumber == "05_120306087_0105_1_2"
                                            || b.SupportItemNumber == "05_120309088_0105_1_2" || b.SupportItemNumber == "05_120603089_0105_1_2" || b.SupportItemNumber == "05_120603090_0105_1_2"
                                            || b.SupportItemNumber == "05_120606091_0105_1_2" || b.SupportItemNumber == "05_120606095_0105_1_2" || b.SupportItemNumber == "05_120606096_0105_1_2"
                                            || b.SupportItemNumber == "05_120606097_0105_1_2" || b.SupportItemNumber == "05_120609099_0105_1_2" || b.SupportItemNumber == "05_120612100_0105_1_2"
                                            || b.SupportItemNumber == "05_122203104_0105_1_2" || b.SupportItemNumber == "05_122203105_0105_1_2" || b.SupportItemNumber == "05_122203106_0105_1_2"
                                            || b.SupportItemNumber == "05_122203107_0105_1_2" || b.SupportItemNumber == "05_122203108_0105_1_2" || b.SupportItemNumber == "05_122203110_0105_1_2"
                                            || b.SupportItemNumber == "05_122203111_0105_1_2" || b.SupportItemNumber == "05_122203112_0105_1_2" || b.SupportItemNumber == "05_122203113_0105_1_2"
                                            || b.SupportItemNumber == "05_122203114_0105_1_2" || b.SupportItemNumber == "05_122203115_0105_1_2" || b.SupportItemNumber == "05_122203117_0105_1_2"
                                            || b.SupportItemNumber == "05_122203118_0105_1_2" || b.SupportItemNumber == "05_122203119_0105_1_2" || b.SupportItemNumber == "05_122203120_0105_1_2"
                                            || b.SupportItemNumber == "05_122209119_0105_1_2" || b.SupportItemNumber == "05_122212120_0105_1_2" || b.SupportItemNumber == "05_122303121_0105_1_2"
                                            || b.SupportItemNumber == "05_122303122_0105_1_2" || b.SupportItemNumber == "05_122303123_0105_1_2" || b.SupportItemNumber == "05_122306124_0105_1_2"
                                            || b.SupportItemNumber == "05_122306125_0105_1_2" || b.SupportItemNumber == "05_122306127_0105_1_2" || b.SupportItemNumber == "05_122306129_0105_1_2"
                                            || b.SupportItemNumber == "05_122306131_0105_1_2" || b.SupportItemNumber == "05_122306132_0105_1_2" || b.SupportItemNumber == "05_122306134_0105_1_2"
                                            || b.SupportItemNumber == "05_122306136_0105_1_2" || b.SupportItemNumber == "05_122306138_0105_1_2" || b.SupportItemNumber == "05_122306139_0105_1_2"
                                            || b.SupportItemNumber == "05_122306140_0105_1_2" || b.SupportItemNumber == "05_122306141_0105_1_2" || b.SupportItemNumber == "05_122312142_0105_1_2"
                                            || b.SupportItemNumber == "05_122315143_0105_1_2" || b.SupportItemNumber == "05_122403144_0105_1_2" || b.SupportItemNumber == "05_122707145_0105_1_2"
                                            || b.SupportItemNumber == "05_122707146_0105_1_2" || b.SupportItemNumber == "05_122707147_0105_1_2" || b.SupportItemNumber == "05_122707148_0105_1_2"
                                            || b.SupportItemNumber == "05_122715149_0105_1_2" || b.SupportItemNumber == "05_122718150_0105_1_2" || b.SupportItemNumber == "05_123103151_0105_1_2"
                                            || b.SupportItemNumber == "05_123103152_0105_1_2" || b.SupportItemNumber == "05_123103153_0105_1_2" || b.SupportItemNumber == "05_123106154_0105_1_2"
                                            || b.SupportItemNumber == "05_123112158_0105_1_2" || b.SupportItemNumber == "05_123115159_0105_1_2" || b.SupportItemNumber == "05_123603161_0105_1_2"
                                            || b.SupportItemNumber == "05_123603162_0105_1_2" || b.SupportItemNumber == "05_123603163_0105_1_2" || b.SupportItemNumber == "05_123603164_0105_1_2"
                                            || b.SupportItemNumber == "05_123603165_0105_1_2" || b.SupportItemNumber == "05_123603166_0105_1_2" || b.SupportItemNumber == "05_123604167_0105_1_2"
                                            || b.SupportItemNumber == "05_123606168_0105_1_2" || b.SupportItemNumber == "05_123612169_0105_1_2" || b.SupportItemNumber == "05_180939182_0105_1_2"
                                            || b.SupportItemNumber == "05_181003192_0105_1_2" || b.SupportItemNumber == "05_181003193_0105_1_2" || b.SupportItemNumber == "05_181006187_0105_1_2"
                                            || b.SupportItemNumber == "05_181006188_0105_1_2" || b.SupportItemNumber == "05_181006189_0105_1_2" || b.SupportItemNumber == "05_181006190_0105_1_2"
                                            || b.SupportItemNumber == "05_181012191_0105_1_2" || b.SupportItemNumber == "05_181024194_0105_1_2" || b.SupportItemNumber == "05_181088195_0105_1_2"
                                            || b.SupportItemNumber == "05_181088196_0105_1_2" || b.SupportItemNumber == "05_501200307_0105_1_2" || b.SupportItemNumber == "05_501200308_0105_1_2"
                                            || b.SupportItemNumber == "05_501224309_0105_1_2" || b.SupportItemNumber == "05_501224310_0105_1_2" || b.SupportItemNumber == "05_501236025_0105_1_2"
                                            || b.SupportItemNumber == "05_501288435_0105_1_2" || b.SupportItemNumber == "05_701206326_0105_1_2" || b.SupportItemNumber == "05_701236327_0105_1_2"
                                            || b.SupportItemNumber == "05_705012333_0105_1_2" || b.SupportItemNumber == "05_711206336_0105_1_2" || b.SupportItemNumber == "05_711236337_0105_1_2"
                                            || b.SupportItemNumber == "05_715012343_0105_1_2" || b.SupportItemNumber == "05_801206345_0105_1_2" || b.SupportItemNumber == "05_801236346_0105_1_2"
                                            || b.SupportItemNumber == "05_805012350_0105_1_2"
                                            select b;

                result = result.Union(a);
            }


            if (model[38].Option.Equals("yes"))
            {
                IEnumerable<Ndis201819> a = from b in _context.Ndis201819
                                            where b.SupportItemNumber == "05_123903170_0113_1_2" || b.SupportItemNumber == "05_123906171_0113_1_2" || b.SupportItemNumber == "05_123909172_0113_1_2"
                                            || b.SupportItemNumber == "05_123915173_0113_1_2" || b.SupportItemNumber == "05_220318209_0113_1_2" || b.SupportItemNumber == "05_220318243_0113_1_2"
                                            || b.SupportItemNumber == "05_220388244_0113_1_2" || b.SupportItemNumber == "05_221200235_0113_1_2" || b.SupportItemNumber == "05_221221236_0113_1_2"
                                            || b.SupportItemNumber == "05_221224238_0113_1_2" || b.SupportItemNumber == "05_221224239_0113_1_2" || b.SupportItemNumber == "05_221803240_0113_1_2"
                                            || b.SupportItemNumber == "05_221818241_0113_1_2" || b.SupportItemNumber == "05_221818242_0113_1_2" || b.SupportItemNumber == "05_221821245_0113_1_2"
                                            || b.SupportItemNumber == "05_222406258_0113_1_2" || b.SupportItemNumber == "05_223021210_0113_1_2" || b.SupportItemNumber == "05_223905273_0113_1_2"
                                            || b.SupportItemNumber == "05_223906274_0113_1_2" || b.SupportItemNumber == "05_223906276_0113_1_2" || b.SupportItemNumber == "05_223906279_0113_1_2"
                                            || b.SupportItemNumber == "05_502218315_0113_1_2" || b.SupportItemNumber == "05_702218330_0113_1_2" || b.SupportItemNumber == "05_712218340_0113_1_2"
                                            || b.SupportItemNumber == "05_802218348_0113_1_2"
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
