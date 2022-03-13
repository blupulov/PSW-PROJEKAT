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

        public List<Doctor> GetAllNonSpecialistDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            foreach (Doctor d in GetAll())
                if (!d.Specialist)
                    doctors.Add(d);
            return doctors;
        }

        public List<Doctor> GetAllSpecialistDoctrs()
        {
            List<Doctor> doctors = new List<Doctor>();
            foreach (Doctor d in GetAll())
                if (d.Specialist)
                    doctors.Add(d);
            return doctors;
        }

        public UserDTO Login(string username, string password)
        {
            foreach(Doctor d in GetAll())
            {
                if (d.Username == username && d.Password == password)
                    return new UserDTO(d);
            }
            return null;
        }
    }
}
