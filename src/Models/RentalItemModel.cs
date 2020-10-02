using Newtonsoft.Json;

namespace Archive.CDManagement.Frontend.Models
{
    public class RentalItemModel
    {
        public int Id { get; set; }

        public int RentalId { get; set; }

        public RentalModel Rental { get; set; }

        public int CDId { get; set; }

        public CDModel CD { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}