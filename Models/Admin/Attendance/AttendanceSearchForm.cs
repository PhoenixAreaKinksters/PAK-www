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
    public class AttendanceSearchForm
    {
        private IConfiguration _configuration;
        public AttendanceSearchForm(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int? PersonId { get; set; }
        public int? EventId { get; set; }

        private IEnumerable<Event> _events { get; set; }
        public IEnumerable<Event> Events
        {
            get
            {
                if (_events == null)
                {
                    try
                    {
                        using (var cn = new MySqlConnection(_configuration.GetConnectionString("PAK")))
                        {
                            _events = cn.Query<Event>("spSearchEvents", new EventSearchForm(), commandType: System.Data.CommandType.StoredProcedure);
                        }
                    }
                    catch
                    {

                    }
                }
                return _events;
            }
        }

        private IEnumerable<Person> _people { get; set; }
        public IEnumerable<Person> People
        {
            get
            {
                if (_people == null)
                {
                    try
                    {
                        using (var cn = new MySqlConnection(_configuration.GetConnectionString("PAK")))
                        {
                            _people = cn.Query<Person>("spSearchPeople", new PersonSearchForm() { ShowAll = 1 }, commandType: System.Data.CommandType.StoredProcedure);
                        }
                    }
                    catch
                    {

                    }
                }
                return _people;
            }
        }
    }
}
