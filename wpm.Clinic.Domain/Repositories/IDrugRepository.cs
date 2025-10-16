using wpm.Clinic.Domain.Entities;

namespace wpm.Clinic.Domain.Repositories
{
    public interface IDrugRepository
    {
        Task<Drug?> GetById(Guid id);
        IEnumerable<Drug> GetAll();
        Task Insert(Drug drug);
        Task Update(Drug drug);
        void Delete(Drug drug);

        Task<int> SaveChanges();
    }
}
