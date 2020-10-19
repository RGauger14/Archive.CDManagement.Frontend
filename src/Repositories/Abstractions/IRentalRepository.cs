using System.Collections.Generic;
using Archive.CDManagement.Frontend.Models;

namespace Archive.CDManagement.Frontend.Repositories.Abstractions
{
    public interface IRentalRepository
    {
        RentalModel Create(RentalModel rental);

        void Delete(int id);

        RentalModel Read(int id);

        void Edit(RentalModel rental);

        List<RentalModel> GetAll();

        void RemoveRentalItem(int rentalId, int rentalItemId);

        void AddRentalItem(RentalItemModel rentalItem);

        void ReturnRental(int id);
    }
}