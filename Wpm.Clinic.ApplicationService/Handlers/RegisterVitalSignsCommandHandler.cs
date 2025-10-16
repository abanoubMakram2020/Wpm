using wpm.Clinic.Domain.Repositories;
using wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKernal.Command;

namespace Wpm.Clinic.ApplicationService.Handlers
{
    public record RegisterVitalSignsCommand(Guid ConsultationId, IEnumerable<VitalSignsReading> VitalSignReadings);
    public record VitalSignsReading(DateTime ReadingDateTime,
                                decimal Temperature,
                                int HeartRate,
                                int RespiratoryRate);
    public class RegisterVitalSignsCommandHandler(IConsultationRepository consultationRepository) : ICommandHandler<RegisterVitalSignsCommand>
    {
        public async Task Handle(RegisterVitalSignsCommand command)
        {
            var consultation = await consultationRepository.GetById(command.ConsultationId);
            consultation!.RegisterVitalSigns(command.VitalSignReadings
                                                   .Select(v => new VitalSigns(v.ReadingDateTime,
                                                                               v.Temperature,
                                                                               v.HeartRate,
                                                                               v.RespiratoryRate)));
            await consultationRepository.SaveChangesAsync();
        }
    }
}
