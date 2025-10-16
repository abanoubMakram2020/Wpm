using wpm.Clinic.Domain.Repositories;
using wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKernal.Command;

namespace Wpm.Clinic.ApplicationService.Handlers
{
    public record AdministerDrugCommand(Guid ConsultationId, Guid DrugId, decimal Quantity, UnitOfMeasure UnitOfMeasure);

    public class AdministerDrugCommandHandler(IConsultationRepository consultationRepository) : ICommandHandler<AdministerDrugCommand>
    {
        public async Task Handle(AdministerDrugCommand command)
        {
            var consultation = await consultationRepository.GetById(command.ConsultationId);
            consultation!.AdministerDrug(command.DrugId, new Dose(command.Quantity, command.UnitOfMeasure));
            await consultationRepository.SaveChangesAsync();
        }
    }
}
