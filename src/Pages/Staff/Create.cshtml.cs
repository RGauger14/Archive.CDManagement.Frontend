using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Archive.CDManagement.Frontend.Pages.Staff
{
    public class CreateStaffModel : PageModel
    {
        private readonly IStaffRepository _staffRepository;

        [BindProperty]
        public StaffModel Staff { get; set; }

        public CreateStaffModel(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _staffRepository.Create(Staff);
            return RedirectToPage("/Staff/Index");
        }
    }
}