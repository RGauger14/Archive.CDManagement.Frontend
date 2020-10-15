using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Archive.CDManagement.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Archive.CDManagement.Frontend.Pages.Staff;
using System.Collections.Generic;

namespace Archive.CDManagement.Frontend.Pages.Rentals
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IStaffRepository _staffRepository;

        public RentalModel Rental { get; set; }
        public List<StaffModel> StaffIds { get; set; }

        public CreateModel(IRentalRepository rentalRepository, IStaffRepository staffRepository)
        {
            _rentalRepository = rentalRepository;
            _staffRepository = staffRepository;
        }

        public void OnGet(int id)
        {
            Rental = _rentalRepository.Read(id);
            StaffIds = _staffRepository.GetAll();
        }

        public void OnPost()
        {
            _rentalRepository.Create(Rental);
        }
    }
}