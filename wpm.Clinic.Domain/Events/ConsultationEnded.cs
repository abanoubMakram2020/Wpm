using Wpm.SharedKernal;

namespace wpm.Clinic.Domain.Events
{
    public record ConsultationEnded(Guid Id, DateTime endedAt) : IDomainEvent;
}
