using System;
using System.Linq;
using Akka.Actor;
using AspNetCoreActor;

public class WeatherForecastActor:ReceiveActor{

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastActor()
        {
            Receive<GetWeatherForecasts>(query =>{

                var rng = new Random();
                var returnValue =  Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();

                Sender.Tell(returnValue);
            });

        }


}