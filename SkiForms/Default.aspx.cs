
using premium.marineweather;
using premium.skiWeather;
using System;
using System.Web.Services;
using System.Web.UI;

namespace SkiForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        


        [WebMethod]
        public static string getSki(string cordinates)
        {
            // set input parameters for the API
            SkiWeatherInput input = new SkiWeatherInput();
            input.query = cordinates;
            input.format = "JSON";
            input.num_of_days = 1;

            // call the location Search method with input parameters
            PremiumAPI api = new PremiumAPI();
            SkiWeather skii=api.GetSkii(input);
            string result= "\r\n SkiApi:"+"\r\n Data: " + skii.data.weather[0].date+ "\r\n Szansa na śnieg: " + skii.data.weather[0].chanceofsnow+ "\r\n Opad całkowity: " + skii.data.weather[0].totalSnowfall_cm+" cm"+"\r\n Wschód Słońca:"+ skii.data.weather[0].astronomy[0].sunrise+"\r\n Zachód Słońca:" + skii.data.weather[0].astronomy[0].sunset;


            return result;


        }
        [WebMethod]
        public static string getMarine(string cordinates)
        {
            // set input parameters for the API
            MarineWeatherInput input = new MarineWeatherInput();
            input.query = cordinates;
            input.format = "JSON";

            // call the location Search method with input parameters
            PremiumAPI api = new PremiumAPI();
            MarineWeather marine=api.GetMarineWeather(input);
            string result = "\r\n MarineApi:" + "\r\n Data: " + marine.data.weather[0].date + "\r\n Godzina: "  + marine.data.weather[0].hourly[3].time/100 +":00" + "\r\n Predkosc wiatru: " + marine.data.weather[0].hourly[3].windspeedKmph +" kmp/h"+ "\r\n Kierunek:" + marine.data.weather[0].hourly[3].winddir16Point+ "\r\n Godzina: " + marine.data.weather[0].hourly[4].time / 100+":00" + "\r\n Predkosc wiatru: " + marine.data.weather[0].hourly[4].windspeedKmph + " kmp/h" + "\r\n Kierunek:" + marine.data.weather[0].hourly[4].winddir16Point;
            return result;


        }
    }
   
}