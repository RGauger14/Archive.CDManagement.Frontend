using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Archive.CDManagement.Frontend.Pages.CDPages
{
    public class CDEditModel : PageModel
    {
        private readonly ICDRepository _cdRepository;
        public CDEditModel(ICDRepository cdRepository)
        {
            _cdRepository = cdRepository; // check naming convention is okay?
        }
        public void OnGet()
        {
        }
    }
}