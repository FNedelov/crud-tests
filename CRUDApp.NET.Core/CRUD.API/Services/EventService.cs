using CRUD.API.Interfaces;
using CRUD.Common;
using CRUD.Common.DTOs;
using CRUD.Common.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CRUD.API.Services
{
    public class EventService : IEventService
    {
        private readonly CrudappContext _dbContext;

        public EventService(CrudappContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateEvent(RequestDataDto eventData)
        {
            try
            {
                string? userName = string.IsNullOrEmpty(eventData.RequestInitiator) ? Constants.SYSTEM : eventData?.RequestInitiator;
                int type;

                // Error has main priority, it  masks other cases.
                if (!string.IsNullOrEmpty(eventData?.Description))
                    type = (int)EventType.Error;
                else
                    type = userName == Constants.SYSTEM ? (int)EventType.System : (int)EventType.User;

                Event eventRecord = new()
                {
                    Type = type,
                    UserName = userName ?? Constants.UNKNOWN,
                    Description = eventData?.Description ?? $"Calling API method: {eventData?.RequestPath}",
                    CreatedDate = DateTime.Now
                };

                _dbContext.Events.Add(eventRecord);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // If we have exception here, we log to EventViewer, instead of SQL table. ex message + ex stacktrace
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    using EventLog eventLog = new("Application");
                    eventLog.Source = "CRUDApp.NET.Core - WebAPI";
                    // eventID = 500 - show that it is an internal server error
                    // category = 9 - filter on this number
                    eventLog.WriteEntry($"{ex.Message}{ex.StackTrace}", EventLogEntryType.Error, 500, 9);
                }
            }
        }
    }
}