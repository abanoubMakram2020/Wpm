using wpm.Management.Domain.ValueObjects;
using wpm.sharedKernal;
using Wpm.SharedKernal;

namespace wpm.Management.Domain.Entities
{
    public class Pet : Entity
    {
        public string Name { get; init; }
        public int Age { get; init; }
        public string Color { get; init; }
        public Weight? Weight { get; private set; }
        public WeightClass WeightClass { get; private set; }
        public SexOfPet SexOfType { get; init; }
        public BreedId BreedId { get; set; }

        public Pet(Guid id, string name, int age, string color, SexOfPet sexOfType, BreedId breedId)
        {
            Id = id;
            Name = name;
            Age = age;
            Color = color;
            SexOfType = sexOfType;
            BreedId = breedId;
        }
        public void SetWeightClass(IBreadService breadService)
        {
            var desiredBreed = breadService.GetBreed(BreedId.Value);

            var (from, to) = SexOfType switch
            {
                SexOfPet.Male => (desiredBreed?.MaleIdealWeight.From, desiredBreed.MaleIdealWeight.To),
                SexOfPet.Female => (desiredBreed?.FemaleIdealWeight.From, desiredBreed.FemaleIdealWeight.To),
                _ => throw new NotImplementedException()
            };

            WeightClass = Weight.Value switch
            {
                _ when Weight.Value < from => WeightClass.Underweight,
                _ when Weight.Value > to => WeightClass.Overweight,
                _ when Weight.Value >= from && Weight.Value <= to => WeightClass.Ideal,
                _ => WeightClass.Unknown
            };
        }

        public void SetWeight(Weight weight, IBreadService breadService)
        {
            Weight = weight;
            SetWeightClass(breadService);
        }

    }

    public enum SexOfPet
    {
        Male,
        Female
    }

    public enum WeightClass
    {
        Unknown,
        Ideal,
        Underweight,
        Overweight,
    }
}
