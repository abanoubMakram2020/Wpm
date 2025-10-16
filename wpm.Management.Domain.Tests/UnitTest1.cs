using wpm.Management.Domain.Entities;
using wpm.Management.Domain.ValueObjects;
using Wpm.SharedKernal.ValueObjects;

namespace wpm.Management.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Pet_should_be_equal()
        {
            var id = Guid.NewGuid();
            var breedService = new BreadService();
            var breedId = new BreedId(breedService._breeds[0].Id, breedService);
            var pet1 = new Pet(id, "Abanoub", 34, "Black", SexOfPet.Male, breedId);
            var pet2 = new Pet(id, "Mariam", 29, "White", SexOfPet.Female, breedId);
            Assert.True(pet1.Equals(pet2));
        }

        [Fact]
        public void Pet_should_be_equal_using_operators()
        {
            var id = Guid.NewGuid();
            var breedService = new BreadService();
            var breedId = new BreedId(breedService._breeds[0].Id, breedService);
            var pet1 = new Pet(id, "Abanoub", 34, "Black", SexOfPet.Male, breedId);
            var pet2 = new Pet(id, "Mariam", 29, "White", SexOfPet.Female, breedId);
            Assert.True(pet1 == pet2);
        }

        [Fact]
        public void Pet_should_not_be_equal_using_operators()
        {
            var breedService = new BreadService();
            var breedId = new BreedId(breedService._breeds[0].Id, breedService);
            var pet1 = new Pet(Guid.NewGuid(), "Abanoub", 34, "Black", SexOfPet.Male, breedId);
            var pet2 = new Pet(Guid.NewGuid(), "Mariam", 29, "White", SexOfPet.Female, breedId);
            Assert.True(pet1 != pet2);
        }

        [Fact]
        public void Weight_should_be_equal()
        {
            var w1 = new Weight(20.0m);
            var w2 = new Weight(20.0m);
            Assert.True(w1 == w2);
        }

        [Fact]
        public void WeightRange_should_be_equal()
        {
            var wr1 = new WeightRange(10.0m, 20.0m);
            var wr2 = new WeightRange(10.0m, 20.0m);
            Assert.True(wr1 == wr2);
        }

        [Fact]
        public void BreedId_should_be_Valid()
        {
            var breadService = new BreadService();
            var id = breadService._breeds[0].Id;
            var breedId = new BreedId(id, breadService);
            Assert.NotNull(breedId);
        }

        [Fact]
        public void BreedId_should_not_be_Valid()
        {
            var breadService = new BreadService();
            var id = Guid.NewGuid();

            Assert.Throws<ArgumentException>(() =>
            {
                var breedId = new BreedId(id, breadService);
            });
        }
        [Fact]
        public void WeightClass_should_be_ideal()
        {
            var breedService = new BreadService();
            var breedId = new BreedId(breedService._breeds[0].Id, breedService);
            var pet = new Pet(Guid.NewGuid(), "Abanoub", 34, "Black", SexOfPet.Male, breedId);
            pet.SetWeight(30.0m, breedService);
            Assert.True(pet.WeightClass == WeightClass.Ideal);
        }

        [Fact]
        public void WeightClass_should_be_underweight()
        {
            var breedService = new BreadService();
            var breedId = new BreedId(breedService._breeds[0].Id, breedService);
            var pet = new Pet(Guid.NewGuid(), "Abanoub", 34, "Black", SexOfPet.Male, breedId);
            pet.SetWeight(20.0m, breedService);
            Assert.True(pet.WeightClass == WeightClass.Underweight);
        }

        [Fact]
        public void WeightClass_should_be_overweight()
        {
            var breedService = new BreadService();
            var breedId = new BreedId(breedService._breeds[0].Id, breedService);
            var pet = new Pet(Guid.NewGuid(), "Abanoub", 34, "Black", SexOfPet.Male, breedId);
            pet.SetWeight(40.0m, breedService);
            Assert.True(pet.WeightClass == WeightClass.Overweight);
        }
    }
}