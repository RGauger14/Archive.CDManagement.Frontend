using System.Collections.Generic;
using System.Linq;
using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Archive.CDManagement.Frontend.Pages.Rentals
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ICDRepository _cDRepository;

        public RentalModel Rental { get; set; }
        public List<CDModel> CDs { get; set; }

        public EditModel(IRentalRepository rentalRepository, ICDRepository cDRepository)
        {
            _rentalRepository = rentalRepository;
            _cDRepository = cDRepository;
        }

        public void OnGet(int id)
        {
            Rental = _rentalRepository.Read(id);
            CDs = _cDRepository.GetAll().Where(cd => !cd.OnLoan).ToList();
        }

        public void OnPostRemoveRentalItem(int rentalItemId)
        {
            _rentalRepository.RemoveRentalItem(Rental.Id, rentalItemId);
            OnGet(Rental.Id);
        }

        public void OnPostAddRentalItem(int cdId)
        {
            var rentalItem = new RentalItemModel
            {
                CDId = cdId,
                RentalId = Rental.Id
            };
            _rentalRepository.AddRentalItem(rentalItem);
            OnGet(Rental.Id);
        }

        public IActionResult OnPostReturnRental()
        {
            _rentalRepository.ReturnRental(Rental.Id);
            return RedirectToPage("/Rentals/Index");
        }
    }
}