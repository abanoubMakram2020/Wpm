using wpm.Management.Domain.Entities;

namespace wpm.Management.Domain.Repositories
{
    public interface IManagementRepository
    {
        Pet? GetById(Guid id);
        IEnumerable<Pet> GetAll();
        void Insert(Pet pet);
        void Update(Pet pet);
        void Delete(Pet pet);
    }
}
