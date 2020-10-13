using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Archive.CDManagement.Frontend.Pages.Staff
{
    public class EditStaffModel : PageModel
    {
        private readonly IStaffRepository _staffRepository;
        
        [BindProperty]
        public StaffModel Staff { get; set;}
        public EditStaffModel(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public void OnGet(int id)
        {
            Staff = _staffRepository.Read(id);
        }

        public IActionResult OnPost(int id)
        {
            _staffRepository.Edit(Staff);
            return RedirectToPage("/StaffIndex");
        }
    }
}