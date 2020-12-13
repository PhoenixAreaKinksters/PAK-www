using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAK_www.Models.Admin
{
    public class RemoveEvent
    {
        private IConfiguration _configuration;
        public RemoveEvent(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public RemoveEventForm Form { get; set; }

        public bool Remove()
        {
            var removed = false;
            try
            {
                using (var cn = new MySqlConnection(_configuration.GetConnectionString("PAK")))
                {
                    removed = cn.Execute("spRemoveEvent", Form, commandType: System.Data.CommandType.StoredProcedure) > 0;
                }
            }
            catch
            {

            }
            return removed;
        }
    }
}
