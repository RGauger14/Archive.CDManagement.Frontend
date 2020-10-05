using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Archive.CDManagement.Frontend.Pages.Rentals
{
    public class CreateModel : PageModel
    {
        private readonly IRentalRepository _rentalRepository;

        public CreateModel(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }
        public void OnGet()
        {
        }
    }
}