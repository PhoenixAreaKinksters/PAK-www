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
    public class PersonSearch
    {
        private IConfiguration _configuration;
        public PersonSearch(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public PersonSearchForm Form { get; set; }
        public bool Search { get; set; }
        private IEnumerable<Person> _people { get; set; }
        public IEnumerable<Person> People
        {
            get
            {
                if (_people == null && Search)
                {
                    try
                    {
                        using (var cn = new MySqlConnection(_configuration.GetConnectionString("PAK")))
                        {
                            _people = cn.Query<Person>("spSearchPeople", Form, commandType: System.Data.CommandType.StoredProcedure);
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
