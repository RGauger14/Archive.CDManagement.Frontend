using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Archive.CDManagement.Frontend.Models
{
    public class RentalModel
    {
        public int Id { get; set; }

        public List<RentalItemModel> RentalItems { get; set; }

        public int StaffId { get; set; }

        public StaffModel Staff { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime DateReturned { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}