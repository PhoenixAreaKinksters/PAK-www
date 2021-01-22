using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAK_www.Models.Admin
{
    public class AttendanceSearch
    {
        private IConfiguration _configuration;
        public AttendanceSearch(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AttendanceSearchForm Form { get; set; }
        public bool Search { get; set; }
    }
}
