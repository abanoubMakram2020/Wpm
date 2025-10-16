using wpm.Clinic.Domain.Repositories;
using Wpm.SharedKernal.Command;
using Wpm.SharedKernal.ValueObjects;

namespace Wpm.Clinic.ApplicationService.Handlers
{
    public class SetWeightCommandHandler(IConsultationRepository consultationRepository) : ICommandHandler<SetWeightCommand>
    {
        public async Task Handle(SetWeightCommand command)
        {
            var consultation = await consultationRepository.GetById(command.Id);
            consultation!.SetWeight(command.Weight);
            await consultationRepository.SaveChangesAsync();
        }
    }
}
