using Wpm.SharedKernal;

namespace wpm.Clinic.Domain.Events
{
    public record DiagnosisUpdated(Guid Id, string diagnosis) : IDomainEvent;
}
