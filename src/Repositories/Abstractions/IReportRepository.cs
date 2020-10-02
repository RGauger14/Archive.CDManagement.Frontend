using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.CDManagement.Frontend.Models;

namespace Archive.CDManagement.Frontend.Repositories.Abstractions
{
    public interface IReportRepository
    {
        ReportModel Read(int id);

    }
}
