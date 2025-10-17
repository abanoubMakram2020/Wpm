using Wpm.SharedKernal;

namespace wpm.Management.Domain.Events
{
    public record PetWeightUpdated(Guid PetId, decimal Weight) : IDomainEvent;

}
