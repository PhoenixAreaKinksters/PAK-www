using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAK_www.Models.Admin
{
    public class EventSearchForm
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string EventTitle { get; set; }
    }
}
