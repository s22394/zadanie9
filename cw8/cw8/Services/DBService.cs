using cw8.DTO;
using cw8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace cw8.Services
{
    public class DBService : IDBService
    {
        private readonly MainDbContext mainDbContext;
        public DBService(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }
        public async Task<string> AddDoctorAsync(DoctorDTO doctorDTO)
        {
            try
            {
                await mainDbContext.AddAsync(new Doctor
                {
                    FirstName = doctorDTO.FirstName,
                    LastName = doctorDTO.LastName,
                    Email = doctorDTO.Email
                });
                await mainDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return "Istnieje już doktor o takim id";
            }
            return "Dodano lekarza";
        }
        public async Task<string> DeleteDoctorAsync(int id)
        {
            
            if (await mainDbContext.Doctors.FindAsync(id) == null)
            {
                return "nie znaleziono doktora";
            }
            mainDbContext.Remove(await mainDbContext.Doctors.FindAsync(id));

            return "Usunieto doktora";

            
        }
        public async Task<IEnumerable<DoctorDTO>> GetDoctorsAsync()
        {

            return await mainDbContext.Doctors.Select(e => new DoctorDTO
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email
            }).ToListAsync();
        }
        public async Task<string> ModifyDoctorAsync(int id, DoctorDTO doctorDTO)
        {


            if (await mainDbContext.Doctors.FindAsync(id) == null)
            {
                return "nie znaleziono doktora";
            }
            var newDoctor = await mainDbContext.Doctors.FindAsync(id);
            
            newDoctor.FirstName = doctorDTO.FirstName;
            newDoctor.LastName = doctorDTO.LastName;
            newDoctor.Email = doctorDTO.Email;

            await mainDbContext.SaveChangesAsync();

            return "zmieniono dane doktora";
        }
        public async Task<PrescriptionDTO> GetPrescriptionAsync(int id)
        {


            if (await mainDbContext.Prescriptions.FindAsync(id) == null)
                //return "nie znaleziono recepty";
                return null;

            PrescriptionDTO prescriptionDTO = await mainDbContext
                .Prescriptions.Where(e => e.IdPrescription == id).Select(e => new PrescriptionDTO
                {
                    PrescriptionDate = e.Date,
                    PrescriptionDueDate = e.DueDate,
                    PatientFirstName = e.Patient.FirstName,
                    PatientLastName = e.Patient.LastName,
                    PatientBirthDate = e.Patient.BirthDate,
                    DoctorFirstName = e.Doctor.FirstName,
                    DoctorLastName = e.Doctor.LastName,
                    DoctorEmail = e.Doctor.Email,
                    Medicaments = e.PrescriptionMedicaments.Select(e => new MedicamentDTO
                    {
                        Name = e.Medicament.Name,
                        Details = e.Details,
                        Dose = e.Dose
                    })
                }).FirstAsync();

            return prescriptionDTO;
        }
        


    }

}
