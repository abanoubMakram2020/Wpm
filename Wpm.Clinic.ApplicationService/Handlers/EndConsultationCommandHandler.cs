using wpm.Clinic.Domain.Repositories;
using Wpm.SharedKernal.Command;

namespace Wpm.Clinic.ApplicationService.Handlers
{
    public record EndConsultationCommand(Guid ConsultationId);

    public class EndConsultationCommandHandler(IConsultationRepository consultationRepository) : ICommandHandler<EndConsultationCommand>
    {
        public async Task Handle(EndConsultationCommand command)
        {
            var consultation = await consultationRepository.GetById(command.ConsultationId);
            consultation!.End();
            await consultationRepository.SaveChangesAsync();
        }
    }
}
