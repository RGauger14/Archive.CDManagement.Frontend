using System.Collections.Generic;
using Archive.CDManagement.Frontend.Models;

namespace Archive.CDManagement.Frontend.Repositories.Abstractions
{
    public interface ICDRepository
    {
        void Create(CDModel cd);

        void Delete(int id);

        CDModel Read(int id);

        void Edit(CDModel cd);

        List<CDModel> GetAll();
    }
}