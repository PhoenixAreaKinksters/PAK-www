using MySql.Data.MySqlClient;
using PAK_www.Models.Shared;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PAK_www.Models.Admin
{
    public class LoginForm
    {
        protected IConfiguration configuration;
        public LoginForm(IConfiguration config)
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
                    user = cn.QueryFirst<User>("spLoginUser", this);
                }
            }
            catch
            {

            }
            return user;
        }
    }
}
