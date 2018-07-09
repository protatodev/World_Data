using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace World_Data.Models
{
    public class Country
    {
        private string name = "";
        private string continent = "";
        private string code = "";
        private long population = 0;
        private double gnp = 0.0;
        private double surfaceArea = 0.0;
        private List<City> cities = new List<City>() { };

        public Country(string name, string continent, string code, long population, double gnp, double surfaceArea)
        {
            this.name = name;
            this.continent = continent;
            this.code = code;
            this.population = population;
            this.gnp = gnp;
            this.surfaceArea = surfaceArea;
        }

        public string GetName()
        {
            return name;
        }

        public string GetContinent()
        {
            return continent;
        }

        public string GetCountryCode()
        {
            return code;
        }

        public long GetPopulation()
        {
            return population;
        }

        public double GetGNP()
        {
            return gnp;
        }

        public double GetSurfaceArea()
        {
            return surfaceArea;
        }
    }
}
