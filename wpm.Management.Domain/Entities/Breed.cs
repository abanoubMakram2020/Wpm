using wpm.Management.Domain.ValueObjects;
using Wpm.SharedKernal;

namespace wpm.Management.Domain.Entities
{
    public class Breed : Entity
    {
        public string Name { get; init; }
        public WeightRange MaleIdealWeight { get; init; }
        public WeightRange FemaleIdealWeight { get; init; }

        public Breed(Guid id, string name, WeightRange maleIdealWeight, WeightRange femaleIdealWeight)
        {
            Id = id;
            Name = name;
            MaleIdealWeight = maleIdealWeight;
            FemaleIdealWeight = femaleIdealWeight;
        }
    }
}
