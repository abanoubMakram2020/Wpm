using Wpm.SharedKernal;

namespace wpm.Clinic.Domain.Events
{
    public record TreatmentUpdated(Guid Id, string treatment) : IDomainEvent;
}
