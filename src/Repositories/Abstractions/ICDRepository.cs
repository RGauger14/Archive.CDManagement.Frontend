using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.CDManagement.Frontend.Models;

namespace Archive.CDManagement.Frontend.Repositories.Abstractions
{
    public interface ICDRepository
    {
        void Create(CDModel cd);

        void Delete(int id);

        CDModel Read(int id);

        void Edit(CDModel cd);

    }
}
