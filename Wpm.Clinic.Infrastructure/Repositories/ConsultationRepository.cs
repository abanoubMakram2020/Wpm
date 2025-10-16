using wpm.Clinic.Domain.Entities;
using wpm.Clinic.Domain.Repositories;


namespace Wpm.Clinic.Infrastructure.Repositories
{
    public class ConsultationRepository : IConsultationRepository
    {
        private readonly ClinicDBContext _clinicDBContext;
        public ConsultationRepository(ClinicDBContext clinicDBContext)
        {
            _clinicDBContext = clinicDBContext;
        }
        public void Delete(Consultation consultation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Consultation> GetAll()
        {
            return _clinicDBContext.Consultations.ToList();
        }

        public async Task<Consultation?> GetById(Guid id)
        {
            return await _clinicDBContext.Consultations.FindAsync(id);
        }

        public async Task Insert(Consultation consultation)
        {
            await _clinicDBContext.Consultations.AddAsync(consultation);
        }

        public async Task Update(Consultation consultation)
        {
            _clinicDBContext.Consultations.Update(consultation);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _clinicDBContext.SaveChangesAsync();
        }
    }
}
