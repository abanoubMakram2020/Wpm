namespace wpm.Clinic.Domain.ValueObjects
{
    public record DrugId
    {
        public Guid Value { get; init; } = Guid.Empty;
        public DrugId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentNullException("value", "DrugId is not valid.");
            Value = value;
        }
        public static implicit operator DrugId(Guid value) => new DrugId(value);
    }
}
