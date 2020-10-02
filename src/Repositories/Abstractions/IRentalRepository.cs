using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.CDManagement.Frontend.Models;

namespace Archive.CDManagement.Frontend.Repositories.Abstractions
{
    public interface IRentalRepository
    {
        void Create(RentalModel rental);

        void Delete(int id);

        RentalModel Read(int id);

        void Edit(RentalModel rental);
    }
}
