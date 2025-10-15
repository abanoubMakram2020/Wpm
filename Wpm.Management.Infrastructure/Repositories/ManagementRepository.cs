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

        public Pet? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Pet pet)
        {
            throw new NotImplementedException();
        }

        public void Update(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
