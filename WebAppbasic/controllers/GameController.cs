using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppbasic.controllers
{
    public class GameController : Controller
    { [HttpGet]
        public IActionResult RandomNumber()
    {
        if (HttpContext.Session.GetString("View") != null && (HttpContext.Session.GetString("View")).CompareTo("Game/RandomNumber/Post") == 0)
        {
            ViewBag.Result = HttpContext.Session.GetString("Result");
            ViewBag.UserGuess = HttpContext.Session.GetInt32("UserGuess");
            ViewBag.GeneratedNumber = HttpContext.Session.GetInt32("RandomNumber");
        }

        int generatedNumber = GuessingGame.getRandomNum();
        HttpContext.Session.SetInt32("RandomNumber", generatedNumber);

        return View();
    }


    [HttpPost]
    public IActionResult RandomNumber(int Num)
    {
        int generatedNumber = Convert.ToInt32(HttpContext.Session.GetInt32("RandomNumber"));
        String result = GuessingGame.getResult(Num, generatedNumber);

        HttpContext.Session.SetString("Result", result);
        HttpContext.Session.SetInt32("UserGuess", Num);

        HttpContext.Session.SetString("View", "Game/RandomNumber/Post");

        return RedirectToAction(nameof(RandomNumber));
    }

}
}