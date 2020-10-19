using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Models.Reports;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Archive.CDManagement.Frontend.Pages.Reports
{
    public class IndexReportModel : PageModel
    {
        public List<IndexReportModel> Report { get; private set;}

        public List<CDRentedModel> CdRentedCount { get; private set; }

        public List<StaffModel> Staff { get; set; }
        public List<CDModel> CDs { get; set; }

        [BindProperty]
        public int StaffIdFilter { get; set; }

        [BindProperty]
        public int CdIdFilter { get; set; }

        private readonly IReportRepository _reportRepository;
        private readonly ICDRepository _cdRepository;
        private readonly IStaffRepository _staffRepository;

        public IndexReportModel(IReportRepository reportRepository, ICDRepository cdRepository, IStaffRepository staffRepository)
        {
            _reportRepository = reportRepository;
            _cdRepository = cdRepository;
            _staffRepository = staffRepository;
        }
        public void OnGet()
        {
            // Report = _reportRepository.GetAll() 
            //  ^^ does not work? not sure why? ^^
            CDs = _cdRepository.GetAll();
            Staff = _staffRepository.GetAll();
            CdRentedCount = _reportRepository.GetAllCdRentedCount();
        }

        public IActionResult OnPostDownloadRentals()
        {
            var stream = _reportRepository.GetRentalsCsv(StaffIdFilter, CdIdFilter);
            return new FileStreamResult(stream, "text/csv")
            {
                FileDownloadName = "rentalReport.csv"
            };
        }
        
        public IActionResult OnPostDownloadCdCount()
        {
            var stream = _reportRepository.GetCdCountCsv();
            return new FileStreamResult(stream, "text/csv")
            {
                FileDownloadName = "cdCountReport.csv"
            };
        }

        public string GetReportsAsJson()
        {
            return JsonConvert.SerializeObject(Report);
        }
    }
}