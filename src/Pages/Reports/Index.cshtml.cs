using System.Collections.Generic;
using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Archive.CDManagement.Frontend.Pages.Reports
{
    public class IndexReportModel : PageModel
    {
        public List<IndexReportModel> Report { get; private set;}
        private readonly IReportRepository _reportRepository;

        public IndexReportModel(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public void OnGet()
        {
           // Report = _reportRepository.GetAll() 
           //  ^^ does not work? not sure why? ^^
        }

        public string GetReportsAsJson()
        {
            return JsonConvert.SerializeObject(Report);
        }
    }
}