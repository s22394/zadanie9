using cw8.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cw8.Services
{
    public interface IDBService
    {
        Task<IEnumerable<DoctorDTO>> GetDoctorsAsync();
        Task<string> AddDoctorAsync(DoctorDTO doctorDTO);
        Task<string> ModifyDoctorAsync(int id, DoctorDTO doctorDTO);
        Task<string> DeleteDoctorAsync(int id);
        Task<PrescriptionDTO> GetPrescriptionAsync(int id);


    }
}

