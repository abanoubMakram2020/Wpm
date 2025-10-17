using Wpm.SharedKernal;

namespace wpm.Clinic.Domain.Events
{
    public record WeightUpdated(Guid Id, decimal Weight) : IDomainEvent;
}
