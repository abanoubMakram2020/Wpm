using Wpm.SharedKernal;

namespace wpm.Clinic.Domain.Events
{
    public record ConsultationStarted(Guid Id, Guid PatientId, DateTime StartedAt) : IDomainEvent;
}
