using bolnica_back.DTOs;
using bolnica_back.Interfaces;
using bolnica_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context): base(context) { }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public void UpdateDoctor(ChangePersonalInfoDTO dto)
        {
            Doctor d = this.FindById(dto.Id);
            d.Name = dto.Name;
            d.Surname = dto.Surname;
            d.Phone = dto.PhoneNumber;
            d.EMail = dto.EMail;
            ApplicationDbContext.SaveChanges();
            
        }
    }
}
