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
    public class Login
    {
        protected IConfiguration configuration;
        public Login(IConfiguration config)
        {
            configuration = config;
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public User ValidateCredentials()
        {
            var user = new User();
            try
            {
                using (var cn = new MySqlConnection(configuration.GetConnectionString("PAK")))
                {
                    user = cn.QueryFirst<User>("spLoginUser", new { Username = Username, Password = Password }, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
            return user;
        }
    }
}
