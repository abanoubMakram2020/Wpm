namespace wpm.Clinic.Domain.ValueObjects
{
    public record Dose
    {
        public decimal Quantity { get; init; }
        public UnitOfMeasure Unit { get; init; }
        public Dose(decimal quantity, UnitOfMeasure unit)
        {
            Quantity = quantity;
            Unit = unit;
        }
        public static implicit operator Dose(decimal value) => new Dose(value);
    }

    public enum UnitOfMeasure
    {
        mg,
        ml,
        tablet,
        g,
        l,
        units,
        capsules,
        drops,
        puffs
    }
}
