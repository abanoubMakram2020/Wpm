using wpm.Management.Domain.Entities;
using wpm.Management.Domain.ValueObjects;

namespace wpm.Management.Domain
{
    public interface IBreadService
    {
        Breed? GetBreed(Guid id);
    }

    public class BreadService : IBreadService
    {
        public readonly List<Breed> _breeds =
        [
            new Breed(Guid.Parse("7a97166b-88c3-45ce-b62a-ba3048633922"), "Labrador", new WeightRange(25, 36),new WeightRange(25, 36)),
            new Breed(Guid.Parse("3c1f76c2-44b8-4862-86cd-2b695772c05d"), "Persian",  new WeightRange(3, 5),  new WeightRange(25, 36)),
            new Breed(Guid.Parse("d31c4d2f-570b-4194-9c42-5867adbc70f5"), "Siamese",  new WeightRange(2m, 4m),new WeightRange(25, 36)),
            new Breed(Guid.Parse("cf8a86d6-ef16-4e6a-b6c8-f45f7e888ab0"), "Bulldog",  new WeightRange(18, 23),new WeightRange(25, 36)),
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
