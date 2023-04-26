using CRUD.Common.DTOs;

namespace CRUD.API.Interfaces
{
    public interface IEventService
    {
        public Task CreateEvent(RequestDataDto eventData);
    }
}