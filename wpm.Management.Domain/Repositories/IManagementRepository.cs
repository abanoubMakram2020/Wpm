using wpm.Management.Domain.Entities;

namespace wpm.Management.Domain.Repositories
{
    public interface IManagementRepository
    {
        Task<Pet?> GetById(Guid id);
        IEnumerable<Pet> GetAll();
        Task Insert(Pet pet);
        Task Update(Pet pet);
        void Delete(Pet pet);

        Task<int> SaveChanges();
    }
}
