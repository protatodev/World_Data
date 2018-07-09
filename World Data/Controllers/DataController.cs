using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using World_Data.Models;

namespace World_Data.Controllers
{
    public class DataController : Controller
    {
        [HttpGet("/form")]
        public ActionResult Form()
        {
            return View();
        }

    }
}