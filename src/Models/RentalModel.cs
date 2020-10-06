using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Archive.CDManagement.Frontend.Models
{
    public class RentalModel
    {
        public int Id { get; set; }

        public List<RentalItemModel> RentalItems { get; set; }

        [Required]
        public int StaffId { get; set; }

        public StaffModel Staff { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateRented { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateReturned { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}