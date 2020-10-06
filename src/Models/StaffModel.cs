using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Archive.CDManagement.Frontend.Models
{
    public class StaffModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(25)]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string MobileNumber { get; set; }

        [Required]
        public bool Active { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}