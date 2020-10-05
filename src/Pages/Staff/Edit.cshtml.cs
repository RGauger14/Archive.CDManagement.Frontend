using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Archive.CDManagement.Frontend.Pages.Staff
{
    public class EditStaffModel : PageModel
    {
        private readonly IStaffRepository _staffRepository;
        public EditStaffModel(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public void OnGet()
        {
        }
    }
}