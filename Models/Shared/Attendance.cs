using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAK_www.Models.Shared
{
    public class Attendance
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; }

        public int PersonId { get; set; }
        public string SceneName { get; set; }
    }
}
