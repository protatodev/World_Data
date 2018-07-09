using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using World_Data;

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

        public static List<City> FindCities(string code)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `city` WHERE countrycode = @countryCode;";

            MySqlParameter countryCode = new MySqlParameter();
            countryCode.ParameterName = "@countryCode";
            countryCode.Value = code;
            cmd.Parameters.Add(countryCode);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            string cityName = "";
            string cityCode = "";
            long cityPop = 0;
            List<City> cityList = new List<City>() { };

            while (rdr.Read())
            {
                cityName = rdr.GetString(1);
                cityCode = rdr.GetString(2);
                cityPop = rdr.GetInt32(4);
                City foundCity = new City(cityName, cityCode, cityPop);
                cityList.Add(foundCity);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return cityList;
        }
    }
}
