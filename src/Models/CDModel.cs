using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Archive.CDManagement.Frontend.Models
{
    public class CDModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Title { get; set; }

        [Required]
        [StringLength(25)]
        public string Author { get; set; }

        [Required]
        [StringLength(10)]
        public string Section { get; set; }

        [Required]
        [Range(0, 1000)]
        public int X { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Y { get; set; }

        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Must be a Number.")]
        [MinLength(13)]
        [MaxLength(13)]
        public string Barcode { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public bool OnLoan { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}