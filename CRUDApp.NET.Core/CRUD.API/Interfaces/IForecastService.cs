using CRUD.Common.DTOs;

namespace CRUD.API.Interfaces
{
    public interface IForecastService
    {
        public Task<ForecastDto[]> GetForecast();
    }
}