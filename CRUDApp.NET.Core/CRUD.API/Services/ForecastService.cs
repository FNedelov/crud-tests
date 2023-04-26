using CRUD.API.Interfaces;
using CRUD.Common.DTOs;

namespace CRUD.API.Services
{
    public class ForecastService : IForecastService
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<ForecastDto[]> GetForecast()
        {
            // Simulate long running task
            await Task.Delay(1000);
            var forecastArray = Enumerable.Range(1, 5).Select(index => new ForecastDto
            {
                Date = DateOnly.FromDateTime(DateTime.Now).AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();

            return forecastArray;
        }
    }
}