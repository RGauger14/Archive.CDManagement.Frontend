using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Archive.CDManagement.Frontend.Models
{
    public class StaffModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public bool Active { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);

        }
    }
}
