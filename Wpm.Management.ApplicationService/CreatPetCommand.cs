using wpm.Management.Domain.Entities;

namespace Wpm.Management.ApplicationService
{
    public record CreatPetCommand(Guid Id, string Name, int Age, string Color, SexOfPet SexOfPet, Guid BreedId);
}
