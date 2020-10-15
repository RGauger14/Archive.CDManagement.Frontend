using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Repositories;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Archive.CDManagement.Frontend.Pages.CDPages
{
    public class CDCreateModel : PageModel
    {
        private readonly ICDRepository _cDRepository;

        [BindProperty]
        public CDModel CD { get; set; }

        public CDCreateModel(ICDRepository cDRepository)
        {
            _cDRepository = cDRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(int id)
        {
            _cDRepository.Create(CD);
            return RedirectToPage("/Cds/Index");
        }

        // TODO - UploadFile
    }
}