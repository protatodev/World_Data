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

        [HttpGet("/results")]
        public ActionResult Results()
        {
            return View();
        }

        [HttpPost("/results")]
        public ActionResult ResultsPost()
        {
            string country = Request.Form["name"];
            Country newCountry = Country.FindCountryByName(country);
            return View("Results", newCountry);
        }

        [HttpGet("/all_countries")]
        public ActionResult All_Countries()
        {
            return View(countryList);
        }

    }
}