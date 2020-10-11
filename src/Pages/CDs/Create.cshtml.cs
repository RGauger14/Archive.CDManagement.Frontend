using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Archive.CDManagement.Frontend.Pages.CDPages
{
    public class CDCreateModel : PageModel
    {
        private readonly ICDRepository _cDRepository;

        public CDCreateModel(ICDRepository cDRepository)
        {
            _cDRepository = cDRepository;
        }
        public void OnGet()
        {
        }

        // TODO - UploadFile
    }
}