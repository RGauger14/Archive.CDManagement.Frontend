using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archive.CDManagement.Frontend.Models.Reports
{
    public class CDRentedModel
    {
        public CDModel CD { get; set; }
        public int RentedCount { get; set; }
    }
}
