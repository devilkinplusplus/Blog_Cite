using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BloqPlus.Areas.Blog.ViewComponents.Admin
{
    public class GetWeather:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string apiKey = "98c32b4b5123be419a816c38cb55cd43";
            string connection = $"https://api.openweathermap.org/data/2.5/weather?q=Baku&mode=xml&lang=en&units=metric&appid={apiKey}";

            XDocument document = XDocument.Load(connection);
            var heat = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.heat = Math.Round(decimal.Parse(heat), 0);

            return View();
        }

    }
}
