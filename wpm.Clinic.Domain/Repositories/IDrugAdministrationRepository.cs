using wpm.Clinic.Domain.Entities;

namespace wpm.Clinic.Domain.Repositories
{
    public interface IDrugAdministrationRepository
    {
        Task<DrugAdministration?> GetById(Guid id);
        IEnumerable<DrugAdministration> GetAll();
        Task Insert(DrugAdministration drugAdministration);
        Task Update(DrugAdministration drugAdministration);
        void Delete(DrugAdministration drugAdministration);

        Task<int> SaveChanges();
    }
}
