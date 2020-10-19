using System.Collections.Generic;
using System.IO;
using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Models.Reports;

namespace Archive.CDManagement.Frontend.Repositories.Abstractions
{
    public interface IReportRepository
    {
        List<ReportModel> GetAll();
        List<CDRentedModel> GetAllCdRentedCount();
        Stream GetRentalsCsv(int staffIdFilter, int cdIdFilter);
        Stream GetCdCountCsv();
    }
}