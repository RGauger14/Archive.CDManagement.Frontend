using Archive.CDManagement.Frontend.Models;

namespace Archive.CDManagement.Frontend.Repositories.Abstractions
{
    public interface IReportRepository
    {
        ReportModel Read(int id);
    }
}