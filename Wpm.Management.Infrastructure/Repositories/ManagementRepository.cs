using wpm.Management.Domain.Entities;
using wpm.Management.Domain.Repositories;

namespace Wpm.Management.Infrastructure.Repositories
{
    public class ManagementRepository : IManagementRepository
    {
        private readonly ManagementDBContext _managementDBContext;
        public ManagementRepository(ManagementDBContext managementDBContext)
        {
            _managementDBContext = managementDBContext;
        }
        public void Delete(Pet pet)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> GetAll()
        {
            return _managementDBContext.Pets.ToList();
        }

        public async Task<Pet?> GetById(Guid id)
        {
            return await _managementDBContext.Pets.FindAsync(id);
        }

        public async Task Insert(Pet pet)
        {
            await _managementDBContext.Pets.AddAsync(pet);
        }

        public async Task Update(Pet pet)
        {
            _managementDBContext.Pets.Update(pet);
        }
        public async Task<int> SaveChanges()
        {
            return await _managementDBContext.SaveChangesAsync();
        }
    }
}
