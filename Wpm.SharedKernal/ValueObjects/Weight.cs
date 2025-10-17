namespace Wpm.SharedKernal.ValueObjects
{
    public record Weight
    {
        public decimal Value { get; init; }
        public Weight(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("value is not valid");
            }
            Value = value;
        }

        public static implicit operator Weight(decimal value) => new Weight(value);
        public static implicit operator decimal(Weight value) => value.Value;
    }
}
