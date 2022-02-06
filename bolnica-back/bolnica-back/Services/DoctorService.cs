using bolnica_back.DTOs;
using bolnica_back.Interfaces;
using bolnica_back.Model;
using System.Collections.Generic;

namespace bolnica_back.Services
{
    public class DoctorService
    {
        private readonly IDoctorRepository doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public List<Doctor> GetAll()
        {
            return (List<Doctor>)doctorRepository.GetAll();
        }

        public void Add(Doctor doctor)
        {
            doctorRepository.Add(doctor);
        }

        public Doctor FindById(long id) 
        {
            return doctorRepository.FindById(id);
        }

        public void Delete(long id)
        {
            doctorRepository.Delete(FindById(id));
        }

        public void UpdateDoctor(ChangePersonalInfoDTO dto)
        {
            doctorRepository.UpdateDoctor(dto);
        }
    }
}
