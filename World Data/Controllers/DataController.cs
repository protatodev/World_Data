using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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

        [HttpPost("/results")]
        public ActionResult ResultsPost()
        {
            string country = Request.Form["name"];
            /*
            string modified = country.Substring(1).ToLower();
            modified.Insert(0, country[0].ToString().ToUpper());
            char[] letterArray = modified.ToCharArray();
            letterArray = Array.FindAll<char>(letterArray, (c => (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-')));
            modified = new string(letterArray);
            */
            Country newCountry = Country.FindCountryByName(country);

            return View("Results", newCountry);
        }

        [HttpGet("/results")]
        public ActionResult Results()
        {
            return View();
        }

        [HttpGet("/all_countries")]
        public ActionResult All_Countries()
        {
            List<Country> countryList = Country.DisplayAllCountries();
            return View(countryList);
        }

    }
}