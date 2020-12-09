using MySql.Data.MySqlClient;
using PAK_www.Models.Shared;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAK_www.Models.Admin
{
    public class LoginForm
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User ValidateCredentials()
        {
            var user = new User();
            try
            {
                using (var cn = new MySqlConnection("foobar"))
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
