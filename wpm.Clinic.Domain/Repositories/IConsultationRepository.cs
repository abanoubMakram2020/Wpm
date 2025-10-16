using wpm.Clinic.Domain.Entities;

namespace wpm.Clinic.Domain.Repositories
{
    public interface IConsultationRepository
    {
        Task<Consultation?> GetById(Guid id);
        IEnumerable<Consultation> GetAll();
        Task Insert(Consultation consultation);
        Task Update(Consultation consultation);
        void Delete(Consultation consultation);

        Task<int> SaveChanges();
    }
}
