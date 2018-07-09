using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using World_Data;

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

        public void PopulateCities()
        {
            cities = City.FindCities(code);
        }

        public List<City> ListCities()
        {
            return cities;
        }

        public static Country FindCountryByName(string cName)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `country` WHERE name = @thisName;";

            MySqlParameter thisName = new MySqlParameter();
            thisName.ParameterName = "@thisName";
            thisName.Value = cName;
            cmd.Parameters.Add(thisName);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            string countryName = "";
            string continentName = "";
            string countryCode = "";
            long pop = 0;
            double revenue = 0.0;
            double area = 0.0;

            while(rdr.Read())
            {
                countryName = rdr.GetString(1);
                continentName = rdr.GetString(2);
                countryCode = rdr.GetString(0);
                pop = (long)rdr.GetInt32(6);
                revenue = (double)rdr.GetFloat(8);
                area = (double)rdr.GetFloat(4);
            }

            Country foundCountry = new Country(countryName, continentName, countryCode, pop, revenue, area);
            foundCountry.PopulateCities();

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }

            return foundCountry;
        }

        public static List<Country> DisplayAllCountries()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `country`;";

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            string countryName = "";
            string continentName = "";
            string countryCode = "";
            long pop = 0;
            double revenue = 0.0;
            double area = 0.0;
            List<Country> countryList = new List<Country>() { };

            while (rdr.Read())
            {
                countryName = rdr.GetString(1);
                continentName = rdr.GetString(2);
                countryCode = rdr.GetString(0);
                pop = (long)rdr.GetInt32(6);
                revenue = (double)rdr.GetFloat(8);
                area = (double)rdr.GetFloat(4);

                Country foundCountry = new Country(countryName, continentName, countryCode, pop, revenue, area);
                countryList.Add(foundCountry);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return countryList;
        }
    }
}
