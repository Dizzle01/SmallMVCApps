using Microsoft.AspNetCore.Mvc;
using SmallMVCApps.Models.FizzBuzz;

namespace SmallMVCApps.Controllers
{
    public class FizzBuzzController : Controller
    {
        [HttpGet]
        public IActionResult FBPage()
        {
            FizzBuzzModel model = new();

            model.FizzValue = 3;
            model.BuzzValue = 5;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FBPage(FizzBuzzModel model)
        {
            if (model.BuzzValue == 0 || model.FizzValue == 0)
            {
                ModelState.AddModelError("BuzzValue", "Es darf keine 0 ausgewählt werden!");
                return View(model);
            }

            List<string> fbItems = new();

            bool isFizz;
            bool isBuzz;

            for (int i = 1; i <= 100; i++)
            {
                isFizz = (i % model.FizzValue == 0);
                isBuzz = (i % model.BuzzValue == 0);

                string fbItem = "";
                if (isFizz)
                {
                    fbItem += "Fizz";
                }
                if (isBuzz)
                {
                    fbItem += "Buzz";
                }
                if (!isFizz && !isBuzz)
                {
                    fbItem = i.ToString();
                }
                fbItems.Add(fbItem);
            }

            model.Result = fbItems;

            return View(model);
        }
    }
}
