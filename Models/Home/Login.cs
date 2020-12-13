using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using PAK_www.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAK_www.Models.Home
{
    public class Login
    {
        protected IConfiguration _configuration;
        public Login(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LoginForm Form { get; set; }

        public User ValidateCredentials()
        {
            var user = new User();
            try
            {
                using (var cn = new MySqlConnection(_configuration.GetConnectionString("PAK")))
                {
                    user = cn.QueryFirst<User>("spLoginUser", Form, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch
            {
                
            }
            return user;
        }
    }
}
