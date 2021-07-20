using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.Calendar.v3;
using Microsoft.Extensions.Configuration;
using Google.Apis.Calendar.v3.Data;

namespace PAK_www.Models.Home
{
    public class Calendar
    {
        private IConfiguration _configuration;
        public Calendar(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        private CalendarService _calendarService { get; set; }
        private CalendarService CalendarService
            =>_calendarService ??= new CalendarService(new BaseClientService.Initializer
                {
                    ApplicationName = "pak-calendar",
                    ApiKey = _configuration["ApiKeys:Google"],
                });

        private async Task<List<Event>> GetEvents()
        {
            var events = await CalendarService.Events.List(_configuration["Calendars:Events"]).ExecuteAsync();
            var eventList = (List<Event>)events.Items;

            return eventList;
        }
    }
}
