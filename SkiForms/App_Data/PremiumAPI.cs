using System;
using System.Configuration;
using System.Web.Script.Serialization;
using premium.skiWeather;
using premium.marineweather;

public class PremiumAPI
{
    public string ApiBaseURL = ConfigurationManager.AppSettings["PremiumApiBaseURL"];
    public string PremiumAPIKey = ConfigurationManager.AppSettings["PremiumAPIKey"];



    public SkiWeather GetSkii(SkiWeatherInput input)
    {
        string apiURL = ApiBaseURL + "ski.ashx?q=" + input.query + "&format=" + input.format + "&num_of_days="+ input.num_of_days + "&callback=" + input.callback + "&key=" + PremiumAPIKey;

        string result = RequestHandler.Process(apiURL);

        SkiWeather ski = null;
        try
        {
            ski = (SkiWeather)new JavaScriptSerializer().Deserialize(result, typeof(SkiWeather));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.GetBaseException());
        }
        //XmlDocument xmlDoc = new XmlDocument();
        //xmlDoc.LoadXml(result);
        //string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "skii.xml");
        //xmlDoc.Save(fileName);
        //XmlSerializer serializer = new XmlSerializer(typeof(SkiWeather));
        //SkiWeather ski=null;
        //using (TextReader reader = new StringReader(result))
        //{
        //    try
        //    {
        //        ski = (SkiWeather)serializer.Deserialize(reader);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.GetBaseException());
        //    }

        // }
        return ski;

    }

    public MarineWeather GetMarineWeather(MarineWeatherInput input)
    {
        string apiURL = ApiBaseURL + "marine.ashx?q=" + input.query + "&format=" + input.format + "&fx=" + input.fx + "&callback=" + input.callback + "&key=" + PremiumAPIKey;

        string result = RequestHandler.Process(apiURL);

        MarineWeather marine = null;
    try
        {
            marine = (MarineWeather)new JavaScriptSerializer().Deserialize(result, typeof(MarineWeather));
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.GetBaseException());
        }
    

    //XmlDocument xmlDoc = new XmlDocument();
    //xmlDoc.LoadXml(result);
    //string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "marine.xml");
    //xmlDoc.Save(fileName);
    //XmlSerializer serializer = new XmlSerializer(typeof(SkiWeather));
    //MarineWeather marine = null;
    //using (TextReader reader = new StringReader(result))
    //{
    //    try
    //    {
    //        marine = (MarineWeather)serializer.Deserialize(reader);
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine(ex.GetBaseException());
    //    }

//}
        return marine;
    }


}