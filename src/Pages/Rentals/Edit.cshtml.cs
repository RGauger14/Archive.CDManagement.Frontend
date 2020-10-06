using System.Collections.Generic;
using System.Linq;
using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Archive.CDManagement.Frontend.Pages.Rentals
{
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
    }
}