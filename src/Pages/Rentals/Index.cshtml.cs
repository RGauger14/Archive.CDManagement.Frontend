using System.Collections.Generic;
using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Archive.CDManagement.Frontend.Pages.Rentals
{
    public class IndexRentalModel : PageModel
    {
        public List<RentalModel> rentals { get; private set;}
        private readonly IRentalRepository _rentalRepository;

        public IndexRentalModel(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }
        public void OnGet()
        {
            rentals = _rentalRepository.GetAll();
        }

        public string GetRentalsAsJson()
        {
            return JsonConvert.SerializeObject(rentals);
        }
    }
}