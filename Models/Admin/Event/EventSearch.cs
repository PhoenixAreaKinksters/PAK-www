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
    public class EventSearch
    {
        private IConfiguration _configuration;
        public EventSearch(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public EventSearchForm Form { get; set; }
        public bool Search { get; set; }
        private IEnumerable<Event> _events { get; set; }
        public IEnumerable<Event> Events
        {
            get
            {
                if (_events == null && Search)
                {
                    try
                    {
                        using (var cn = new MySqlConnection(_configuration.GetConnectionString("PAK")))
                        {
                            _events = cn.Query<Event>("spSearchEvents", Form, commandType: System.Data.CommandType.StoredProcedure);
                        }
                    }
                    catch
                    {

                    }
                }
                return _events;
            }
        }
    }
}
