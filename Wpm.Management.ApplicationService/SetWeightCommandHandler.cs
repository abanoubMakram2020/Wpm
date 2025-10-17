using wpm.Management.Domain;
using wpm.Management.Domain.Events;
using wpm.Management.Domain.Repositories;
using Wpm.SharedKernal.Command;
using Wpm.SharedKernal.ValueObjects;

namespace Wpm.Management.ApplicationService
{
    public class SetWeightCommandHandler : ICommandHandler<SetWeightCommand>
    {
        private readonly IManagementRepository managementRepository;
        private readonly IBreadService breadService;

        public SetWeightCommandHandler(IManagementRepository managementRepository, IBreadService breadService)
        {
            this.managementRepository = managementRepository;
            this.breadService = breadService;
           
            DomainEvents.PetWeightUpdatedDispatcher.Subscribe((evt) =>
            {
                // Here you can handle the event, e.g., logging or further processing
                Console.WriteLine($"Pet weight updated: PetId={evt.PetId}, NewWeight={evt.Weight}");
            });

        }
        public async Task Handle(SetWeightCommand command)
        {
            var pet = await managementRepository.GetById(command.Id);
            pet!.SetWeight(command.Weight, breadService);
            await managementRepository.SaveChanges();
        }
    }
}
