using wpm.Management.Domain;
using wpm.Management.Domain.Entities;
using wpm.Management.Domain.Repositories;
using wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.ApplicationService
{
    public class ManagementApplicationService(IBreadService breadService, IManagementRepository managementRepository)
    {
        public async Task Handle(CreatPetCommand command)
        {
            var breedId = new BreedId(command.BreedId, breadService);
            var newPet = new Pet(command.Id,
                command.Name,
                command.Age,
                command.Color,
                command.SexOfPet,
                breedId);

            await managementRepository.Insert(newPet);
            await managementRepository.SaveChanges();
        }
    }
}
