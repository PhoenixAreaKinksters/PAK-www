using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAK_www.Models.Shared
{
    public class Person
    {
        public int PersonId { get; set; }
        public string LegalName { get; set; }
        public string SceneName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime? VettedDate { get; set; }
    }
}
