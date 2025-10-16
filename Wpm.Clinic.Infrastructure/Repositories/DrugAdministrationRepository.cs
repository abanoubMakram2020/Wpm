using wpm.Clinic.Domain.Entities;
using wpm.Clinic.Domain.Repositories;

namespace Wpm.Clinic.Infrastructure.Repositories
{
    public class DrugAdministrationRepository : IDrugAdministrationRepository
    {
        private readonly ClinicDBContext _clinicDBContext;
        public DrugAdministrationRepository(ClinicDBContext clinicDBContext)
        {
            _clinicDBContext = clinicDBContext;
        }
        public void Delete(DrugAdministration drugAdministration)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DrugAdministration> GetAll()
        {
            return _clinicDBContext.DrugAdministrations.ToList();
        }

        public async Task<DrugAdministration?> GetById(Guid id)
        {
            return await _clinicDBContext.DrugAdministrations.FindAsync(id);
        }

        public async Task Insert(DrugAdministration drugAdministration)
        {
            await _clinicDBContext.DrugAdministrations.AddAsync(drugAdministration);
        }

        public async Task Update(DrugAdministration drugAdministration)
        {
            _clinicDBContext.DrugAdministrations.Update(drugAdministration);
        }
        public async Task<int> SaveChanges()
        {
            return await _clinicDBContext.SaveChangesAsync();
        }
    }
}
