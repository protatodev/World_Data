using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace World_Data.Models
{
    public class City
    {
        private string name = "";
        private string code = "";
        private long population = 0;

        public City(string name, string code, long population)
        {
            this.name = name;
            this.code = code;
            this.population = population;
        }

        public string GetName()
        {
            return name;
        }

        public string GetCode()
        {
            return code;
        }

        public long GetPopulation()
        {
            return population;
        }
    }
}
