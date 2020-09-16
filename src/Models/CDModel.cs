using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archive.CDManagement.Frontend.Models
{
    public class CDModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Section { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Barcode { get; set; }

        public string Description { get; set; }

        public bool OnLoan { get; set; }
    }
}
