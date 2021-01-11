using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppbasic.controllers
{
    public class tempController : Controller
    {
        [HttpGet]
        public IActionResult FeverCheck()
        {
            HttpContext.Session.SetString("View", "Temp/FeverCheck");
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(double BodyTemp)
        {
            HttpContext.Session.SetString("View", "Temp/FeverCheck");
            string recommendation = Doctor.giveRecomendation(BodyTemp);

            ViewBag.Recommendation = recommendation;

          
            return View();
        }
    }
}