using bolnica_back.DTOs;
using bolnica_back.Model;

namespace bolnica_back.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        void UpdateDoctor(ChangePersonalInfoDTO dto);
    }
}
