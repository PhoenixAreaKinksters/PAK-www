using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using PAK_www.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAK_www.Models.Admin
{
    public class EditEvent
    {
        private IConfiguration _configuration;
        public EditEvent(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int? EventId { get; set; }
        private Event _currentEvent { get; set; }
        public Event CurrentEvent
        {
            get
            {
                if (_currentEvent == null && EventId.HasValue)
                {
                    try
                    {
                        using (var cn = new MySqlConnection(_configuration.GetConnectionString("PAK")))
                        {
                            _currentEvent = cn.QueryFirst<Event>("spSearchEvents", new { ID = EventId, FromDate = (DateTime?)null, ToDate = (DateTime?)null, Title = (string)null }, commandType: System.Data.CommandType.StoredProcedure);
                        }
                    }
                    catch
                    {

                    }
                }
                return _currentEvent;
            }
        }

        public int SaveEvent()
        {
            try
            {
                using (var cn = new MySqlConnection(_configuration.GetConnectionString("PAK")))
                {
                    if (CurrentEvent.EventId == 0)
                    {
                        CurrentEvent.EventId = cn.QueryFirst<int>("spAddEvent", new { CurrentEvent.Title, CurrentEvent.Link, CurrentEvent.Date, CurrentEvent.Description }, commandType: System.Data.CommandType.StoredProcedure);
                    }
                    else
                    {
                        var updated = (cn.Execute("spEditEvent", CurrentEvent, commandType: System.Data.CommandType.StoredProcedure) == 1);
                        if (!updated)
                        {
                            CurrentEvent.EventId = 0;
                        }
                    }
                }
            }
            catch
            {
                CurrentEvent.EventId = 0;
            }
            return CurrentEvent.EventId;
        }
    }
}
