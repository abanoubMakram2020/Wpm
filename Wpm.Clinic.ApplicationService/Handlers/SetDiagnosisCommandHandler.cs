using wpm.Clinic.Domain.Repositories;
using Wpm.SharedKernal.Command;

namespace Wpm.Clinic.ApplicationService.Handlers
{
    public record SetDiagnosisCommand(Guid ConsultationId, string Diagnosis);

    public class SetDiagnosisCommandHandler(IConsultationRepository consultationRepository) : ICommandHandler<SetDiagnosisCommand>
    {
        public async Task Handle(SetDiagnosisCommand command)
        {
            var consultation = await consultationRepository.GetById(command.ConsultationId);
            consultation!.SetDiagnosis(command.Diagnosis);
            await consultationRepository.SaveChangesAsync();
        }
    }
}
