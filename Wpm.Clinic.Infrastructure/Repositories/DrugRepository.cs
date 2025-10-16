using wpm.Clinic.Domain.Entities;
using wpm.Clinic.Domain.Repositories;

namespace Wpm.Clinic.Infrastructure.Repositories
{
    public class DrugRepository : IDrugRepository
    {
        private readonly ClinicDBContext _clinicDBContext;
        public DrugRepository(ClinicDBContext clinicDBContext)
        {
            _clinicDBContext = clinicDBContext;
        }
        public void Delete(Drug drug)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Drug> GetAll()
        {
            return _clinicDBContext.Drugs.ToList();
        }

        public async Task<Drug?> GetById(Guid id)
        {
            return await _clinicDBContext.Drugs.FindAsync(id);
        }

        public async Task Insert(Drug drug)
        {
            await _clinicDBContext.Drugs.AddAsync(drug);
        }

        public async Task Update(Drug drug)
        {
            _clinicDBContext.Drugs.Update(drug);
        }
        public async Task<int> SaveChanges()
        {
            return await _clinicDBContext.SaveChangesAsync();
        }
    }
}
