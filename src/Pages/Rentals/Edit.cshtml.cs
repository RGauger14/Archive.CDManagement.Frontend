using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Archive.CDManagement.Frontend.Pages.Rentals
{
    public class EditModel : PageModel
    {
        private readonly IRentalRepository _rentalRepository;

        public EditModel(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }
        public void OnGet()
        {
        }
    }
}