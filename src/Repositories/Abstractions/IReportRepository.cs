using System.Collections.Generic;
using Archive.CDManagement.Frontend.Models;

namespace Archive.CDManagement.Frontend.Repositories.Abstractions
{
    public interface IReportRepository
    {
        List<ReportModel> GetAll();
    }
}