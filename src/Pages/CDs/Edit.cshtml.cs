using System.Collections.Generic;
using System.IO;
using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Archive.CDManagement.Frontend.Pages.CDPages
{
    public class CDEditModel : PageModel 
    {
        private readonly ICDRepository _cdRepository;

        private readonly IHostingEnvironment _hostingEnvironment;
        
        [BindProperty]

        public CDModel CD { get; set;}
        public CDEditModel(ICDRepository cdRepository, IHostingEnvironment hostingEnvironment)
        {
            _cdRepository = cdRepository;
            _hostingEnvironment = hostingEnvironment;
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
            CD = _cdRepository.Read(CD.Id);

            if (file.Length > 0)
            {
                // var filePath = Path.GetTempFileName();
                var fileName = $"{System.Guid.NewGuid().ToString()}_{ file.FileName}";
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images",fileName);
                CD.ThumbnailFilePath = filePath;
                CD.ThumbnailFileName = fileName;
                using (var stream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                }
                _cdRepository.Edit(CD);
            }
            return RedirectToPage($"/CDs/Edit/{CD.Id}");
        }
    }
}