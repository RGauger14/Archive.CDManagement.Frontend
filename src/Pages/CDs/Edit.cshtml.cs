using System.Collections.Generic;
using System.IO;
using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Archive.CDManagement.Frontend.Pages.CDPages
{
    public class CDEditModel : PageModel
    {
        private readonly ICDRepository _cdRepository;
        
        [BindProperty]

        public CDModel CD { get; set;}
        public CDEditModel(ICDRepository cdRepository)
        {
            _cdRepository = cdRepository;
        }
        public void OnGet(int id)
        {
            CD = _cdRepository.Read(id);
        }

        public IActionResult OnPost(int id)
        {
            CD.Id = id;
            _cdRepository.Edit(CD);
            return RedirectToPage("/CDs/Index");
        }

        public IActionResult OnPostUploadFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                var filePath = Path.GetTempFileName();
                using (var stream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                }
            }
            return RedirectToPage("/CDs/Index");
        }
    }
}