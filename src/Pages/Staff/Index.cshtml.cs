using System.Collections.Generic;
using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Archive.CDManagement.Frontend.Pages.Staff
{
    public class IndexStaffModel : PageModel
    {
        public List<StaffModel> Staff { get; private set; }
        private readonly IStaffRepository _staffRepository;

        public IndexStaffModel(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public void OnGet()
        {
            Staff = _staffRepository.GetAll();
        }

        public string GetStaffAsJson()
        {
            return JsonConvert.SerializeObject(Staff);
        }

        public IActionResult OnPostDelete(int staffId)
        {
            _staffRepository.Delete(staffId);
            return RedirectToPage("/Staff/Index");
        }
    }
}