using wpm.Management.Domain.Entities;
using wpm.Management.Domain.ValueObjects;

namespace wpm.Management.Domain
{
    public interface IBreadService
    {
        Breed? GetBreed(Guid id);
    }

    public class FakeBreadService : IBreadService
    {
        public readonly List<Breed> _breeds =
        [
            new Breed(Guid.NewGuid(), "Labrador", new WeightRange(25, 36),new WeightRange(25, 36)),
            new Breed(Guid.NewGuid(), "Persian",  new WeightRange(3, 5),  new WeightRange(25, 36)),
            new Breed(Guid.NewGuid(), "Siamese",  new WeightRange(2m, 4m),new WeightRange(25, 36)),
            new Breed(Guid.NewGuid(), "Bulldog",  new WeightRange(18, 23),new WeightRange(25, 36)),
        ];
        public Breed? GetBreed(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Breed is not valid");
            }
            var result = _breeds.Find(b => b.Id == id);
            return result ?? throw new ArgumentException("Breed was not found");
        }
    }
}
