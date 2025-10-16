using wpm.Clinic.Domain.Repositories;
using Wpm.SharedKernal.Command;

namespace Wpm.Clinic.ApplicationService.Handlers
{
    public record SetTreatmentCommand(Guid ConsultationId, string Treatment);

    public class SetTreatmentCommandHandler(IConsultationRepository consultationRepository) : ICommandHandler<SetTreatmentCommand>
    {
        public async Task Handle(SetTreatmentCommand command)
        {
            var consultation = await consultationRepository.GetById(command.ConsultationId);
            consultation!.SetTreatment(command.Treatment);
            await consultationRepository.SaveChangesAsync();
        }
    }
}
