using Wpm.SharedKernal;

namespace wpm.Management.Domain.Events
{
    public static class DomainEvents
    {
        public static DomainEventDispatcher<PetWeightUpdated> PetWeightUpdatedDispatcher { get; } = new();
    }
}
