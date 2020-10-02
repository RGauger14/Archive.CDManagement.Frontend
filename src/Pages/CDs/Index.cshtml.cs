using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Archive.CDManagement.Frontend.Pages.CDPages
{
    public class CDIndexModel : PageModel
    {
        public CDModel CD { get; private set; }
        private readonly ICDRepository _cdRepository;

        public CDIndexModel(ICDRepository cdRepository)
        {
            _cdRepository = cdRepository;
        }

        public void OnGet()
        {
            CD = _cdRepository.Read(0);
        }
    }
}