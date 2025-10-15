namespace wpm.Management.Domain.ValueObjects
{
    public record BreedId
    {
        private readonly IBreadService _breadService;
        public Guid Value { get; init; }

        private BreedId(Guid value)
        {
            Value = value;
        }

        public static BreedId Create(Guid value)
        {
            return new BreedId(value);
        }
        public BreedId(Guid value, IBreadService breadService)
        {
            _breadService = breadService;
            ValidateBread(value);
            Value = value;
        }

        private void ValidateBread(Guid value)
        {
            if (_breadService.GetBreed(value) == null)
            {
                throw new ArgumentException("Bread is not valid");
            }
        }
    }
}
