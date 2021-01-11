using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppbasic.controllers
{
    public class AppController : Controller
    {
        public IActionResult About()

        {
            HttpContext.Session.SetString("View", "App/About");
            return View();
        }
            
    }
}
