using Archive.CDManagement.Frontend.Models;

namespace Archive.CDManagement.Frontend.Repositories.Abstractions
{
    public interface IStaffRepository
    {
        void Create(StaffModel staff);

        void Delete(int id);

        StaffModel Read(int id);

        void Edit(StaffModel staff);
    }
}