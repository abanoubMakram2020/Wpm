using wpm.Clinic.Domain.Entities;
using wpm.Clinic.Domain.Repositories;

namespace Wpm.Clinic.ApplicationService.Handlers
{
    public record StartConsultationCommand(Guid PatientId);
    public class StartConsultationCommandHandler(IConsultationRepository consultationRepository)
    {
        public async Task<Guid> Handle(StartConsultationCommand command)
        {
            var newConsultation = new Consultation(command.PatientId);
            await consultationRepository.Insert(newConsultation);
            await consultationRepository.SaveChangesAsync();
            return newConsultation.Id;
        }
    }
}
