using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Archive.CDManagement.Frontend.Pages.Staff
{
    public class CreateStaffModel : PageModel
    {
        private readonly IStaffRepository _staffRepository;

        public CreateStaffModel(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public void OnGet()
        {
        }
    }
}