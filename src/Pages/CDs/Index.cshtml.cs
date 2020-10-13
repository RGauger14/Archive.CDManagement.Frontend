using System.Collections.Generic;
using System.Globalization;
using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Archive.CDManagement.Frontend.Pages.CDPages
{
    public class CDIndexModel : PageModel
    {
        public List<CDModel> CDs { get; private set;}
        private readonly ICDRepository _cdRepository;

        public CDIndexModel(ICDRepository cdRepository)
        {
            _cdRepository = cdRepository;
        }

        public void OnGet()
        {
            CDs = _cdRepository.GetAll();
        }

        public string GetCdsAsJson()
        {
            return JsonConvert.SerializeObject(CDs);
        }

        public void OnPostDelete(int cdId)
        {
            _cdRepository.Delete(cdId);
            OnGet();
        }
    }
}