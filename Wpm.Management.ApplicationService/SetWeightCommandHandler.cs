using wpm.Management.Domain;
using wpm.Management.Domain.Repositories;
using Wpm.SharedKernal.Command;

namespace Wpm.Management.ApplicationService
{
    public class SetWeightCommandHandler(IManagementRepository managementRepository, IBreadService breadService) : ICommandHandler<SetWeightCommand>
    {
        public async Task Handle(SetWeightCommand command)
        {
            var pet = await managementRepository.GetById(command.Id);
            pet.SetWeight(command.Weight, breadService);
            await managementRepository.SaveChanges();
        }
    }
}
