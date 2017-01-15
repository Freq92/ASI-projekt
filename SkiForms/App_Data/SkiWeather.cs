using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace premium.skiWeather
{

    public class SkiWeatherInput
    {
        public string query { get; set; }
        public int num_of_days { get; set; }
        public string format { get; set; }
        public string callback { get; set; }
    }

    public class SkiWeather
    {
        public Data data;
    }


    public class Data
    {
        public List<Request> request;
        public List<Weather> weather;
        public List<Nearest_area> nearest_area;
    }

    public class Request
    {
        public string query { get; set; }
        public string type { get; set; }
    }

    public class Weather
    {
        public DateTime date { get; set; }
        public List<Hourly> hourly { get; set; }
        public List<Astronomy> astronomy { get; set; }
        public int chanceofsnow { get; set; }
        public float totalSnowfall_cm { get; set; }
        public int maxtempC { get; set; }
        public int mintempC { get; set; }
     
    }
    
    public class Nearest_area
    {
        public string arenaName { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public float distance_miles { get; set; }

    }
    public class Astronomy
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string moonrise { get; set; }
        public string moonset { get; set; }
    }
    public class Hourly
    {
    public int time { get; set; }
    public int tempC { get; set; }
    public int tempF { get; set; }
    public int windspeedMiles { get; set; }
    public int windspeedKmph { get; set; }
    public int winddirDegree { get; set; }
    public string winddirection { get; set; }
    public int weatherCode { get; set; }
    public List<WeatherDesc> weatherDesc { get; set; }
    public List<WeatherIconUrl> weatherIconUrl { get; set; }
    public float precipMM { get; set; }
    public float precipInches { get; set; }
    public float humidity { get; set; }
    public int visibility { get; set; }
    public int visibilityMiles { get; set; }
    public int pressure { get; set; }

    public int pressureInches { get; set; }
    public int cloudcover { get; set; }
    public int chanceofrain { get; set; }
    public int chanceofwindy { get; set; }
    public int chanceofovercast { get; set; }
    public int chanceofsunny { get; set; }
    public int chanceoffrost { get; set; }
    public int chanceoffog { get; set; }
    public int chanceofsnow { get; set; }
    public int chanceofthunder { get; set; }
    public int freezeLevel { get; set; }
    public float snowfall_cm { get; set; }
    }
    public class WeatherDesc
    {
        public string value { get; set; }
    }

    public class WeatherIconUrl
    {
        public string value { get; set; }
    }


   
}