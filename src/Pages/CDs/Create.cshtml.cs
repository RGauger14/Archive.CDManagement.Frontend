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

        public void OnPost()
        {
            _cDRepository.Create(CD);
        }

        // TODO - UploadFile
    }
}