using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAK_www.Models.Admin
{
    public class ChangePasswordForm : LoginForm
    {
        public string NewPassword { get; set; }
    }
}
